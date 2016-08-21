using System.Web.Http.Routing;
using InfoDigest.Domain;

namespace InfoDigest.WebAPI.Models
{
    public class QuestionModel
    {
        public string Url { get; set; }
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public int QuestionCategoryId { get; set; }
        public byte[] ImageBytes { get; set; }
        public bool IsDeprecated { get; set; }

        //required by WebAPI to parse posted data
        public QuestionModel()
        {
        }

        public QuestionModel(UrlHelper urlHelper, Question question)
        {
            Url = urlHelper.Link("questions", new { id = question.Id});
            Id = question.Id;
            QuestionText = question.QuestionText;
            QuestionCategoryId = question.CategoryId;
            ImageBytes = question.Image;
            IsDeprecated = question.Deprecated;
        }
    }
}