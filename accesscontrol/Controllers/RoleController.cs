using accesscontrol.Model;
using accesscontrol.Permission;
using accesscontrol.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace accesscontrol.Controllers
{
    public class RoleController : BaseController<RoleModel>
    {
        public RoleController(IRoleService service) : base(service)
        {
        }

        [Authorize(Roles = RolePermission.GetRole)]
        public override async Task<ActionResult<List<RoleModel>>> GetAsync(bool active = true)
        {
            return await base.GetAsync(active);
        }

        [Authorize(Roles = RolePermission.GetRoleById)]
        public override async Task<ActionResult<RoleModel>> GetAsync(int id)
        {
            return await base.GetAsync(id);
        }

        [Authorize(Roles = RolePermission.AddRole)]
        public override async Task<ActionResult<RoleModel>> PostAsync([FromBody]RoleModel item)
        {
            return await base.PostAsync(item);
        }

        [Authorize(Roles = RolePermission.EditRole)]
        public override async Task<IActionResult> PutAsync(int id, RoleModel item)
        {
            return await base.PutAsync(id, item);
        }

        [Authorize(Roles = RolePermission.DeleteRole)]
        public override async Task<IActionResult> DeleteAsync(int id)
        {
            return await base.DeleteAsync(id);
        }
    }
}