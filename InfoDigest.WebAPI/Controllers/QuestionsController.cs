using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using InfoDigest.DataLayer.Repositories;
using InfoDigest.WebAPI.Models;

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
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpPatch]
        public void Patch(int id, [FromBody] string value)
        {
            
        }

        // DELETE: api/questions/5
        public void Delete(int id)
        {
        }
    }
}
