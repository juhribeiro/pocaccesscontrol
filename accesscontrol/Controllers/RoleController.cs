using accesscontrol.Model;
using accesscontrol.Service;
using accesscontrol.Services.Base;

namespace accesscontrol.Controllers
{
    public class RoleController : BaseController<RoleModel>
    {
        public RoleController(IRoleService service) : base(service)
        {
        }
    }
}