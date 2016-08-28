using System;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Routing;
using InfoDigest.DataLayer.Repositories;
using InfoDigest.WebAPI.Models;
using Marvin.JsonPatch;

namespace InfoDigest.WebAPI.Controllers
{
    [RoutePrefix("api/questions")]
    public class QuestionsController : BaseApiController
    {
        public QuestionsController(IInfoDigestApplicationUnit appUnit) : base(appUnit)
        {
        }

        [HttpGet]
        [Route("", Name="allquestions")]
        public async Task<IHttpActionResult> GetAllQuestions(int page = 1, int pageSize = 2)
        {
            try
            {
                if (page < 1)
                    return BadRequest("Paging starts with page number 1");

                var totalQuestionCount = await TheApplicationUnit.Questions.GetAll().CountAsync();
                var totalPages = (int) Math.Ceiling((double) totalQuestionCount/pageSize);
                
                var allQuestions =
                    TheApplicationUnit.Questions
                        .GetAll()
                        .OrderBy(x => x.Id)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();

                var urlHelper = new UrlHelper(Request);
                var pagingInformation = 
                    new
                    {
                        totalPages = totalPages,
                        totalCount = totalQuestionCount,
                        prevPage = page > 1 ? urlHelper.Link("allquestions", new { page = page - 1, pageSize }) : "",
                        nextPage = page <= totalPages ? urlHelper.Link("allquestions", new {page = page + 1, pageSize}) : ""
                    };

                HttpContext.Current.Response.Headers.Add("X-pagination",
                    Newtonsoft.Json.JsonConvert.SerializeObject(pagingInformation));

                if (!allQuestions.Any())
                {
                    return NotFound();
                }

                return Ok(allQuestions.Select(ModelFactory.Create));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("{id}", Name = "questions")]
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                var specificQuestion =
                    await TheApplicationUnit.Questions
                        .GetById(id);//todo::implement asynchronous API

                if (specificQuestion == null)
                {
                    return NotFound();
                }

                return Ok(ModelFactory.Create(specificQuestion));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route]
        [ResponseType(typeof(QuestionModel))]
        public IHttpActionResult Post([FromBody]QuestionModel value)
        {
            try
            {
                if (value == null)
                    return BadRequest("Couldn't parse posted tada as QuestionModel");
                if (value.Id > 0)
                    return BadRequest("Question shouldn't contain Id");
                if (value.QuestionCategoryId <= 0)
                    return BadRequest("Please provide question category");

                //todo::need to pass in the answer options as well
                var entity = ModelFactory.Parse(value);
                TheApplicationUnit.Questions.Add(entity);
                TheApplicationUnit.SaveChanges();

                value = ModelFactory.Create(entity);
                return Created(value.Url, value);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult Put(int id, [FromBody]QuestionModel value)
        {
            try
            {
                if (value == null)
                    return BadRequest();
                if(!value.IsValidForPut())
                    return BadRequest("Question text, category, and id must be provided");

                var entity = ModelFactory.Parse(value);
                TheApplicationUnit.Questions.Update(entity);
                TheApplicationUnit.SaveChanges();

                return Ok(ModelFactory.Create(entity));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<IHttpActionResult> Patch(int id, [FromBody] JsonPatchDocument<QuestionModel> patchedQuestion)
        {
            try
            {
                if (patchedQuestion == null)
                    return BadRequest();

                var question = await TheApplicationUnit.Questions.GetById(id);
                if (question == null)
                    return NotFound();

                var questionModel = ModelFactory.Create(question);
                patchedQuestion.ApplyTo(questionModel);

                TheApplicationUnit.Questions.Update(ModelFactory.Parse(questionModel));
                TheApplicationUnit.SaveChanges();

                return Ok(questionModel);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Provided id isn't valid");

                var question = await TheApplicationUnit.Questions.GetById(id);
                if (question == null)
                {
                    return NotFound();
                }

                TheApplicationUnit.Questions.Delete(question);

                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("{questionId}/answers")]
        public async Task<IHttpActionResult> GetQuestionAnswers(int questionId)
        {
            try
            {
                var question = await TheApplicationUnit.Questions.GetById(questionId);
                if (question == null)
                    return NotFound();

                var questionAnswers = 
                    await TheApplicationUnit
                            .AnswerOptions
                            .GetAll()
                            .Where(x => x.QuestionId == question.Id)
                            .ToListAsync();

                return Ok(questionAnswers.Select(x => ModelFactory.Create(x)));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
