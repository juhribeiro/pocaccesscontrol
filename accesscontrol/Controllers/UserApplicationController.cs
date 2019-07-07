using accesscontrol.Model;
using accesscontrol.Permission;
using accesscontrol.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace accesscontrol.Controllers
{
    public class UserApplicationController : BaseController<UserApplicationModel>
    {
        public UserApplicationController(IUserApplicationService service) : base(service)
        {
        }

        [Authorize(Roles = UserApplicationPermission.GetUserApplication)]
        public override async Task<ActionResult<List<UserApplicationModel>>> GetAsync(bool active = true)
        {
            return await base.GetAsync(active);
        }

        [Authorize(Roles = UserApplicationPermission.GetUserApplicationById)]
        public override async Task<ActionResult<UserApplicationModel>> GetAsync(int id)
        {
            return await base.GetAsync(id);
        }

        [Authorize(Roles = UserApplicationPermission.AddUserApplication)]
        public override async Task<ActionResult<UserApplicationModel>> PostAsync([FromBody]UserApplicationModel item)
        {
            return await base.PostAsync(item);
        }

        [Authorize(Roles = UserApplicationPermission.EditUserApplication)]
        public override async Task<IActionResult> PutAsync(int id, UserApplicationModel item)
        {
            return await base.PutAsync(id, item);
        }

        [Authorize(Roles = UserApplicationPermission.DeleteUserApplication)]
        public override async Task<IActionResult> DeleteAsync(int id)
        {
            return await base.DeleteAsync(id);
        }
    }
}