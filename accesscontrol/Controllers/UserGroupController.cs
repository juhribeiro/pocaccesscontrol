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
    public class UserGroupController : BaseController<UserGroupModel>
    {
        public UserGroupController(IUserGroupService service) : base(service)
        {
        }


        [Authorize(Roles = UserGroupPermission.GetUserGroup)]
        public override async Task<ActionResult<List<UserGroupModel>>> GetAsync(bool active = true)
        {
            return await base.GetAsync(active);
        }

        [Authorize(Roles = UserGroupPermission.GetUserGroupById)]
        public override async Task<ActionResult<UserGroupModel>> GetAsync(int id)
        {
            return await base.GetAsync(id);
        }

        [Authorize(Roles = UserGroupPermission.AddUserGroup)]
        public override async Task<ActionResult<UserGroupModel>> PostAsync([FromBody]UserGroupModel item)
        {
            return await base.PostAsync(item);
        }

        [Authorize(Roles = UserGroupPermission.EditUserGroup)]
        public override async Task<IActionResult> PutAsync(int id, UserGroupModel item)
        {
            return await base.PutAsync(id, item);
        }

        [Authorize(Roles = UserGroupPermission.DeleteUserGroup)]
        public override async Task<IActionResult> DeleteAsync(int id)
        {
            return await base.DeleteAsync(id);
        }
    }
}