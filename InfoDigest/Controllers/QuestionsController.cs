using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Validation.Providers;
using System.Web.WebSockets;
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
