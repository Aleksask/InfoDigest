using InfoDigest.DataLayer.Repositories;

namespace InfoDigest.WebAPI.Controllers
{
    public class AnswersController :BaseApiController
    {
        protected AnswersController(IInfoDigestApplicationUnit appUnit) : base(appUnit)
        {
        }
    }
}