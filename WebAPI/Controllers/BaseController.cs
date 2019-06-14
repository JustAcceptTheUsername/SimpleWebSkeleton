using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebAPI.Controllers
{
    [Authorize]
    public abstract class BaseController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Version() => Json("Web API");

        [HttpGet]
        public IHttpActionResult Test() => Json("Test successful");

        public virtual IHttpActionResult CheckForErrors(bool value) => value ? Json("Success") : Json("Fail");
    }
}