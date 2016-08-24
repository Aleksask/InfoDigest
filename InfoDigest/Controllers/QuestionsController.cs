using System;
using System.Linq;
using System.Web.Http;
using InfoDigest.DataLayer.Repositories;
using InfoDigest.Models;

namespace InfoDigest.Controllers
{
    [RoutePrefix("api/questions")]
    public class QuestionsController : BaseApiController
    {
        public QuestionsController(IInfoDigestApplicationUnit applicationUnit) : base(applicationUnit)
        {
        }

        public IHttpActionResult Get()
        {
            var stuff = TheApplicationUnit.Questions.GetAll().ToList();
            return Ok();
        }

        public IHttpActionResult Post([FromBody] QuestionModel question)
        {
            throw new NotImplementedException();
        }
    }
}
