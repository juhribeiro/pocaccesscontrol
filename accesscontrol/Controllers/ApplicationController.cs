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
    public class ApplicationController : BaseController<ApplicationModel>
    {
        public ApplicationController(IApplicationService service) : base(service)
        {
        }

        [Authorize(Roles = ApplicationPermission.GetApplication)]
        public override async Task<ActionResult<List<ApplicationModel>>> GetAsync(bool active = true)
        {
            return await base.GetAsync(active);
        }

        [Authorize(Roles = ApplicationPermission.GetApplicationById)]
        public override async Task<ActionResult<ApplicationModel>> GetAsync(int id)
        {
            return await base.GetAsync(id);
        }

        [Authorize(Roles = ApplicationPermission.AddApplication)]
        public override async Task<ActionResult<ApplicationModel>> PostAsync([FromBody]ApplicationModel item)
        {
            return await base.PostAsync(item);
        }

        [Authorize(Roles = ApplicationPermission.EditApplication)]
        public override async Task<IActionResult> PutAsync(int id, ApplicationModel item)
        {
            return await base.PutAsync(id, item);
        }

        [Authorize(Roles = ApplicationPermission.DeleteApplication)]
        public override async Task<IActionResult> DeleteAsync(int id)
        {
            return await base.DeleteAsync(id);
        }
    }
}