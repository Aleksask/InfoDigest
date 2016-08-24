using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using System.Web.Http;
using InfoDigest.DataLayer.Repositories;

namespace InfoDigest.WebAPI.Controllers
{
    [RoutePrefix("api/questioncategories")]
    public class QuestionCategoryController : BaseApiController
    {
        protected QuestionCategoryController(IInfoDigestApplicationUnit appUnit) : base(appUnit)
        {
        }

        [HttpGet]
        [Route("", Name="questionCategories")]
        public async Task<IHttpActionResult> GetAll()
        {
            try
            {
                var questionCategories = 
                    await TheApplicationUnit.QuestionCategories.GetAll()
                            .ToListAsync();
                if (questionCategories.Count == 0)
                    return NotFound();

                return Ok(questionCategories.Select(x => ModelFactory.Create(x)));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("{id}", Name = "questionCategory")]

        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                var questionCategory =
                    await TheApplicationUnit.QuestionCategories.GetById(id);
                if (questionCategory == null)
                    return NotFound();
                return Ok(ModelFactory.Create(questionCategory));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}