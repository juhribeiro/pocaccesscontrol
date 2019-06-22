using System.Collections.Generic;
using System.Threading.Tasks;
using accesscontrol.Model;
using accesscontrol.Permission;
using accesscontrol.Service;
using accesscontrol.Services.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace accesscontrol.Controllers
{
    public class UserController : BaseController<UserModel>
    {
        private readonly IUserService userService;

        public UserController(IUserService service) : base(service)
        {
            this.userService = service;
        }

        [Authorize(Roles = UserPermission.GetUser)]
        public override async Task<ActionResult<List<UserModel>>> GetAsync(bool active = true)
        {
            return await base.GetAsync(active);
        }

        [Authorize(Roles = UserPermission.GetUserById)]
        public override async Task<ActionResult<UserModel>> GetAsync(int id)
        {
            return await base.GetAsync(id);
        }

        [Authorize(Roles = UserPermission.DeleteUser)]
        public override async Task<IActionResult> DeleteAsync(int id)
        {
            return await base.DeleteAsync(id);
        }

        [HttpGet("group/{groupId}")]
        [Authorize(Roles = UserPermission.GetUserByGroup)]
        public async Task<ActionResult<List<UserModel>>> GetByGroupAsync(int groupId)
        {
            return await this.userService.GetByGroupIdAsync(groupId);
        }

        [HttpGet("application/{applicationId}")]
        [Authorize(Roles = UserPermission.GetUserByApplication)]
        public async Task<ActionResult<List<UserModel>>> GetByApplicationAsync(int applicationId)
        {
            return await this.userService.GetByApplicationIdAsync(applicationId);
        }
    }
}