using System.Collections.Generic;
using System.Threading.Tasks;
using accesscontrol.ExceptionMiddleware;
using accesscontrol.Model;
using accesscontrol.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace accesscontrol.Controllers
{
    [Route("/api/[controller]")]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService service;
        private readonly IAuthService auth;

        public SecurityController(ISecurityService service, IAuthService auth)
        {
            this.service = service;
            this.auth = auth;
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        [Produces("application/json")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> LoginAsync([FromBody]LoginModel login)
        {
            var token = await this.service.LoginAsync(login);
            return this.Ok(token);
        }

        [HttpPost]
        [Route("ResetPassword")]
        [AllowAnonymous]
        [Produces("application/json")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> ResetPasswordAsync(ResetPasswordModel reset)
        {
            await this.service.ResetPasswordAsync(reset);
            return this.Ok();
        }

        [HttpPost]
        [Route("ChangePassword")]
        [AllowAnonymous]
        [Produces("application/json")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> ChangePasswordAsync([FromBody]ChangePasswordModel change)
        {
            if (this.ModelState.IsValid)
            {
                await this.service.ChangePasswordAsync(change);
                return this.Ok();
            }

            throw new CustomException(new MessageDetails(Enums.MessageType.Error, "NewPassword and ConfirmPassword not matches"));
        }
    }
}