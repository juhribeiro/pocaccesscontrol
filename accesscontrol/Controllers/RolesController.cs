using accesscontrol.Model;
using accesscontrol.Service;
using accesscontrol.Services.Base;

namespace accesscontrol.Controllers
{
    public class RolesController : BaseController<RoleModel>
    {
        public RolesController(IRoleService service) : base(service)
        {
        }
    }
}