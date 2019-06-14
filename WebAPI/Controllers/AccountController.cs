using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebAPI.Infrastructure;

namespace WebAPI.Controllers
{
    public class AccountController : ApiController
    {
        [RoutePrefix("api/Accounts")]
        public class AccountsController : BaseController
        {
            private AuthRepository _repo = null;

            public AccountsController()
            {
                _repo = new AuthRepository();
            }

            // POST api/Accounts/Register
            [AllowAnonymous]
            [Route("Register")]
            public async Task<IHttpActionResult> Register(UserModel userModel)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                IdentityResult result = await _repo.RegisterUser(userModel);

                IHttpActionResult errorResult = GetErrorResult(result);

                if (errorResult != null)
                {
                    return errorResult;
                }

                return Ok();
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    _repo.Dispose();
                }

                base.Dispose(disposing);
            }

            private IHttpActionResult GetErrorResult(IdentityResult result)
            {
                if (result == null)
                {
                    return InternalServerError();
                }

                if (!result.Succeeded)
                {
                    if (result.Errors != null)
                    {
                        foreach (string error in result.Errors)
                        {
                            ModelState.AddModelError("", error);
                        }
                    }

                    if (ModelState.IsValid)
                    {
                        // No ModelState errors are available to send, so just return an empty BadRequest.
                        return BadRequest();
                    }

                    return BadRequest(ModelState);
                }

                return null;
            }
        }
    }
}