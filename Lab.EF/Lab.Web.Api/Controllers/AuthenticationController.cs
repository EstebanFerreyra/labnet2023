using Lab.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lab.Web.Api.Controllers
{
    [AllowAnonymous]
    public class AuthenticationController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Login(AuthenticationView authenticationView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            // Aca le pagariamos a la base de datos para comprobar los datos del usuario y los permisos que tiene.
            
            bool isCredentialValid = (authenticationView.Password == "messiElMejor");
            if (isCredentialValid)
            {
                var token = TokenGenerator.GenerateTokenJwt(authenticationView.UserName);
                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
