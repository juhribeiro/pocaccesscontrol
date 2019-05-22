using accesscontrol.Model;
using accesscontrol.Service;
using accesscontrol.Services.Base;

namespace accesscontrol.Controllers
{
    public class UserGroupController : BaseController<UserGroupModel>
    {
        public UserGroupController(IUserGroupService service) : base(service)
        {
        }
    }
}