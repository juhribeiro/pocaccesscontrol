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
    public class RoleGroupController : BaseController<RoleGroupModel>
    {
        public RoleGroupController(IRoleGroupService service) : base(service)
        {
        }
        
        [Authorize(Roles = RoleGroupPermission.GetRoleGroup)]
        public override async Task<ActionResult<List<RoleGroupModel>>> GetAsync(bool active = true)
        {
            return await base.GetAsync(active);
        }

        [Authorize(Roles = RoleGroupPermission.GetRoleGroupById)]
        public override async Task<ActionResult<RoleGroupModel>> GetAsync(int id)
        {
            return await base.GetAsync(id);
        }

        [Authorize(Roles = RoleGroupPermission.AddRoleGroup)]
        public override async Task<ActionResult<RoleGroupModel>> PostAsync([FromBody]RoleGroupModel item)
        {
            return await base.PostAsync(item);
        }

        [Authorize(Roles = RoleGroupPermission.EditRoleGroup)]
        public override async Task<IActionResult> PutAsync(int id, RoleGroupModel item)
        {
            return await base.PutAsync(id, item);
        }

        [Authorize(Roles = RoleGroupPermission.DeleteRoleGroup)]
        public override async Task<IActionResult> DeleteAsync(int id)
        {
            return await base.DeleteAsync(id);
        }
    }
}