using System.Web.Http.Routing;
using InfoDigest.Domain;

namespace InfoDigest.WebAPI.Models
{
    public class QuestionCategoryModel
    {
        public string Url { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }

        public QuestionCategoryModel()
        {
        }

        public QuestionCategoryModel(UrlHelper urlHelper, QuestionCategory questionCategory)
        {
            Url = urlHelper.Link("questionCategory", new { id = questionCategory.Id });
            Id = questionCategory.Id;
            Name = questionCategory.CategoryName;
        }
    }
}