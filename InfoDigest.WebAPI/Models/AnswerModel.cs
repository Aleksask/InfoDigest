using System.Web.Http.Routing;
using InfoDigest.Domain;

namespace InfoDigest.WebAPI.Models
{
    public class AnswerModel
    {
        public string Url { get; set; }
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public bool IsCorrect { get; set; }
        public string AnswerText { get; set; }
        public string AnswerUrl { get; set; }
        public string AnswerExplanation { get; set; }
        
        public AnswerModel()
        {
        }

        public AnswerModel(UrlHelper urlHelper, AnswerOption answer)
        {
            Url = urlHelper.Link("answer", new {id = answer.Id});
            Id = answer.Id;
            IsCorrect = answer.IsCorrect;
            QuestionId = answer.QuestionId;
            AnswerText = answer.AnswerText;
            AnswerUrl = answer.AnswerUrl;
            AnswerExplanation = answer.AnswerExplanation;
        }
    }
}