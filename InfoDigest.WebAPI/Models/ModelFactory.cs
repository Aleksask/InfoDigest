using System;
using System.Net.Http;
using System.Web.Http.Routing;
using InfoDigest.Domain;

namespace InfoDigest.WebAPI.Models
{
    public class ModelFactory
    {
        private readonly UrlHelper _urlHelper;

        public ModelFactory(HttpRequestMessage request)
        {
            _urlHelper = new UrlHelper(request);
        }

        public QuestionModel Create(Question question)
        {
            return new QuestionModel(_urlHelper, question);
        }

        public Question Parse(QuestionModel model)
        {
            try
            {
                return new Question
                {
                    Id = model.Id,
                    CategoryId = model.QuestionCategoryId,
                    QuestionText = model.QuestionText,
                    Image = model.ImageBytes,
                    Deprecated = model.IsDeprecated
                };
            }
            catch (Exception ex)
            {
                //todo::log the exception
                return null;
            }
        }
    }
}