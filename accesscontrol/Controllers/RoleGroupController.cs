using accesscontrol.Model;
using accesscontrol.Service;
using accesscontrol.Services.Base;

namespace accesscontrol.Controllers
{
    public class RoleGroupController : BaseController<RoleGroupModel>
    {
        public RoleGroupController(IRoleGroupService service) : base(service)
        {
        }
    }
}