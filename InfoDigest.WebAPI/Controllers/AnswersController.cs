using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using InfoDigest.DataLayer.Repositories;
using InfoDigest.Domain;

namespace InfoDigest.WebAPI.Controllers
{
    [RoutePrefix("api")]
    public class AnswersController :BaseApiController
    {
        public AnswersController(IInfoDigestApplicationUnit appUnit) : base(appUnit)
        {
        }

        //[HttpGet]
        //[Route("{id}", Name = "answer")]
        //public async Task<IHttpActionResult> Get(int id)
        //{
        //    try
        //    {
        //        var answer = await TheApplicationUnit.AnswerOptions.GetById(id);
        //        if (answer == null)
        //            return NotFound();

        //        return Ok(ModelFactory.Create(answer));
        //    }
        //    catch (Exception ex)
        //    {
        //        return InternalServerError(ex);
        //    }
        //}
        [HttpGet]
        [Route("answers/{id}", Name = "answer")]
        [Route("questions/{questionId}/answers/{id}")]
        public async Task<IHttpActionResult> Get(int id, int? questionId = null)
        {
            try
            {
                AnswerOption answer;
                if (questionId != null)
                {
                    var question = await TheApplicationUnit.Questions.GetById(questionId.Value);
                    answer = question.AnswerOptions.FirstOrDefault(x => x.Id == id);
                }
                else
                {
                    answer = await TheApplicationUnit.AnswerOptions.GetById(id);
                }

                if (answer == null)
                {
                    return NotFound();
                }

                return Ok(ModelFactory.Create(answer));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}