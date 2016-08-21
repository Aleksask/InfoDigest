using System.Web.Http;
using InfoDigest.DataLayer.Repositories;
using InfoDigest.WebAPI.Models;

namespace InfoDigest.WebAPI.Controllers
{
    public class BaseApiController : ApiController
    {
        protected IInfoDigestApplicationUnit TheApplicationUnit { get; }

        protected BaseApiController(IInfoDigestApplicationUnit appUnit)
        {
            TheApplicationUnit = appUnit;
        }

        private ModelFactory _modelFactory;
        protected ModelFactory ModelFactory
        {
            get { return _modelFactory = _modelFactory ?? new ModelFactory(Request); }
        }
    }
}