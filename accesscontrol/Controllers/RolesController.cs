using accesscontrol.Model;
using accesscontrol.Services.Base;

namespace accesscontrol.Controllers
{
    public class RolesController : BaseController<RoleModel>
    {
        public RolesController(IBaseService<RoleModel> service) : base(service)
        {
        }
    }
}