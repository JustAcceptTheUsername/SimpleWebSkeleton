using AppServices.Implementations;
using AutoCatalogue.AppServices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class TypeController : BaseController
    {
        private TypeManagementService typeService = new TypeManagementService();

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Json(typeService.Get());
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Json(typeService.GetByID(id));
        }

        [HttpPost]
        public IHttpActionResult Post(TypeDTO typeDTO)
        {
            return CheckForErrors(typeService.Save(typeDTO));
        }

        [HttpPost]
        public IHttpActionResult Update(int id, TypeDTO typeDTO)
        {
            return CheckForErrors(typeService.Update(id, typeDTO));
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            return CheckForErrors(typeService.Delete(id));
        }
    }
}