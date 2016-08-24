using System.Web.Http;
using InfoDigest.DataLayer.Repositories;
using InfoDigest.Models;

namespace InfoDigest.Controllers
{
    public class BaseApiController : ApiController
    {
        private readonly IInfoDigestApplicationUnit _appUnit;
        protected IInfoDigestApplicationUnit TheApplicationUnit
        {
            get { return _appUnit; }
        }
        
        public BaseApiController(IInfoDigestApplicationUnit appUnit)
        {
            _appUnit = appUnit;
        }

        private ModelFactory _modelFactory;
        public ModelFactory ModelFactory
        {
            get { return _modelFactory = _modelFactory ?? new ModelFactory(Request); }
        }
    }
}