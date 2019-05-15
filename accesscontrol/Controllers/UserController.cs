using accesscontrol.Model;
using accesscontrol.Service;
using accesscontrol.Services.Base;

namespace accesscontrol.Controllers
{
    public class UserController : BaseController<UserModel>
    {
        public UserController(IUserService service) : base(service)
        {
        }
    }
}