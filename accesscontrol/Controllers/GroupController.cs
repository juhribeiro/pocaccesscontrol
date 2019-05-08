using accesscontrol.Model;
using accesscontrol.Services.Base;

namespace accesscontrol.Controllers
{
    public class GroupController : BaseController<GroupModel>
    {
        public GroupController(IBaseService<GroupModel> service) : base(service)
        {
        }
    }
}