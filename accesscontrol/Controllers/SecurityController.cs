using System.Collections.Generic;
using System.Threading.Tasks;
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

        public SecurityController(ISecurityService service)
        {
            this.service = service;
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

        // GET api/values
        [HttpGet("")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Get()
        {
            return this.Ok("value1");
        }

        // GET api/values
        [HttpGet("{id}")]
        [Authorize(Roles = "Teste")]
        public async Task<ActionResult> Get(int id)
        {
            return this.Ok("value1");
        }
    }
}