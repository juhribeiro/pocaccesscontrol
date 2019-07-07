using accesscontrol.Model;
using accesscontrol.Permission;
using accesscontrol.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace accesscontrol.Controllers
{
    public class GroupController : BaseController<GroupModel>
    {
        public GroupController(IGroupService service) : base(service)
        {
        }

        [Authorize(Roles = GroupPermission.GetGroup)]
        public override async Task<ActionResult<List<GroupModel>>> GetAsync(bool active = true)
        {
            return await base.GetAsync(active);
        }

        [Authorize(Roles = GroupPermission.GetGroupById)]
        public override async Task<ActionResult<GroupModel>> GetAsync(int id)
        {
            return await base.GetAsync(id);
        }

        [Authorize(Roles = GroupPermission.AddGroup)]
        public override async Task<ActionResult<GroupModel>> PostAsync([FromBody]GroupModel item)
        {
            return await base.PostAsync(item);
        }

        [Authorize(Roles = GroupPermission.EditGroup)]
        public override async Task<IActionResult> PutAsync(int id, GroupModel item)
        {
            return await base.PutAsync(id, item);
        }

        [Authorize(Roles = GroupPermission.DeleteGroup)]
        public override async Task<IActionResult> DeleteAsync(int id)
        {
            return await base.DeleteAsync(id);
        }
    }
}