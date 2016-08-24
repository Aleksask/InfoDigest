using System;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using InfoDigest.DataLayer.Repositories;
using InfoDigest.Domain;
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
        [Route("")]
        public IHttpActionResult Get()
        {
            try
            {
                var allQuestions =
                    TheApplicationUnit.Questions
                        .GetAll()
                        .ToList();

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
    }
}
