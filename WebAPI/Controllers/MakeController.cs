using AppServices.Implementations;
using AutoCatalogue.AppServices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class MakeController : BaseController
    {
        private MakeManagementService makeService = new MakeManagementService();

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Json(makeService.Get());
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Json(makeService.GetByID(id));
        }

        [HttpPost]
        public IHttpActionResult Post(MakeDTO makeDTO)
        {
            return CheckForErrors(makeService.Save(makeDTO));
        }

        [HttpPost]
        public IHttpActionResult Update(int id, MakeDTO makeDTO)
        {
            return CheckForErrors(makeService.Update(id, makeDTO));
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            return CheckForErrors(makeService.Delete(id));
        }
    }
}