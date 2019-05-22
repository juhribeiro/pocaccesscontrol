using accesscontrol.Model;
using accesscontrol.Service;
using accesscontrol.Services.Base;

namespace accesscontrol.Controllers
{
    public class UserApplicationController : BaseController<UserApplicationModel>
    {
        public UserApplicationController(IUserApplicationService service) : base(service)
        {
        }
    }
}