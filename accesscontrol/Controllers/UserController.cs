using accesscontrol.Model;
using accesscontrol.Services.Base;

namespace accesscontrol.Controllers
{
    public class UserController : BaseController<UserModel>
    {
        public UserController(IBaseService<UserModel> service) : base(service)
        {
        }
    }
}