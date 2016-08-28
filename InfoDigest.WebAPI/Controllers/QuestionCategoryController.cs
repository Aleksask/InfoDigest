using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using System.Web.Http;
using InfoDigest.DataLayer.Repositories;
using InfoDigest.WebAPI.Helpers;

namespace InfoDigest.WebAPI.Controllers
{
    [RoutePrefix("api/questioncategories")]
    public class QuestionCategoryController : BaseApiController
    {
        public QuestionCategoryController(IInfoDigestApplicationUnit appUnit) : base(appUnit)
        {
        }

        [HttpGet]
        [Route("", Name="questionCategories")]
        public async Task<IHttpActionResult> GetAll(string sort = "id")
        {
            try
            {
                var questionCategories = 
                    await TheApplicationUnit
                            .QuestionCategories
                            .GetAll()
                            .ApplySort(sort)
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
                if (id <= 0)
                    return BadRequest("Question category id is invalid");

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

        [HttpGet]
        [Route("{id}/questions")]
        public async Task<IHttpActionResult> GetCategoryQuestions(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Question category id is invalid");

                var categoryQuestions =
                    await TheApplicationUnit
                                .Questions
                                .GetAll()
                                .Where(x => x.CategoryId == id)
                                .ToListAsync();

                if (categoryQuestions.Count == 0)
                    return NotFound();

                return Ok(categoryQuestions.Select(ModelFactory.Create));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}