using System;
using System.Data.SqlTypes;
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

        public QuestionCategoryModel Create(QuestionCategory questionCategory)
        {
            return new QuestionCategoryModel(_urlHelper, questionCategory);
        }

        public QuestionCategory Parse(QuestionCategoryModel model)
        {
            try
            {
                return new QuestionCategory {Id = model.Id, CategoryName = model.Name};
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public AnswerModel Create(AnswerOption answer)
        {
            return new AnswerModel(_urlHelper, answer);
        }

        public AnswerOption Parse(AnswerModel model)
        {
            try
            {
                return new AnswerOption
                {
                    AnswerExplanation = model.AnswerExplanation,
                    AnswerText = model.AnswerText,
                    Id = model.Id,
                    QuestionId = model.QuestionId,
                    AnswerUrl = model.AnswerUrl,
                    IsCorrect = model.IsCorrect
                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}