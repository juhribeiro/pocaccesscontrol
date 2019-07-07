using accesscontrol.ExceptionMiddleware;
using accesscontrol.Model;
using accesscontrol.Permission;
using accesscontrol.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace accesscontrol.Controllers
{
    public class ApplicationController : BaseController<ApplicationModel>
    {
        private readonly IApplicationService _service;

        public ApplicationController(IApplicationService service) : base(service)
        {
            this._service = service;
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

        [HttpPost("Register")]
        public async Task<ActionResult<ApplicationModel>> RegisterAsync([FromBody]RegisterApplicationModel item)
        {
            if (this.ModelState.IsValid)
            {
                item = await this._service.RegisterAsync(item);
                return Created(nameof(item), new { id = item.Application.Id });
            }

            throw new CustomException(new MessageDetails(Enums.MessageType.Error, MessagesErrorsModel(this.ModelState)));
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