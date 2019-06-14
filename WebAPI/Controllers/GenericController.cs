using AppServices.Implementations;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public abstract class GenericController<TService, TDTO> : BaseController
        where TService : IService<TDTO>, new()
        where TDTO : class
    {
        private readonly TService _service;

        public GenericController(TService service)
        {
            _service = service;
        }

        public GenericController() : this(new TService())
        {
        }

        [HttpGet]
        public IHttpActionResult Get() => Json(_service.Get());

        [HttpGet]
        public IHttpActionResult Get(int id) => Json(_service.GetByID(id));

        [HttpPost]
        public IHttpActionResult Post(TDTO dto) => CheckForErrors(_service.Save(dto));

        [HttpPost]
        public IHttpActionResult Update(int id, TDTO dto) => CheckForErrors(_service.Update(id, dto));

        [HttpDelete]
        public IHttpActionResult Delete(int id) => CheckForErrors(_service.Delete(id));
    }
}