using AppServices.Implementations;
using AutoCatalogue.AppServices.DTOs;
using System.Web.Http;

namespace WebAPI.Controllers
{
    
    public class CarController : BaseController
    {
        private CarManagementService carService = new CarManagementService();

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Json(carService.Get());
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Json(carService.GetByID(id));
        }

        [HttpPost]
        public IHttpActionResult Post(CarDTO carDTO)
        {
            return CheckForErrors(carService.Save(carDTO));
        }

        [HttpPost]
        public IHttpActionResult Update(int id, CarDTO carDTO)
        {
            return CheckForErrors(carService.Update(id, carDTO));
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            return CheckForErrors(carService.Delete(id));
        }
    }
}