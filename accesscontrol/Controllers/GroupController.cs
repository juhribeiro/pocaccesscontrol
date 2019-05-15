using accesscontrol.Model;
using accesscontrol.Service;
using accesscontrol.Services.Base;

namespace accesscontrol.Controllers
{
    public class GroupController : BaseController<GroupModel>
    {
        public GroupController(GroupService service) : base(service)
        {
        }
    }
}