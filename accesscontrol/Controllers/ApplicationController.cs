using accesscontrol.Model;
using accesscontrol.Services.Base;

namespace accesscontrol.Controllers
{
    public class ApplicationController : BaseController<ApplicationModel>
    {
        public ApplicationController(IBaseService<ApplicationModel> service) : base(service)
        {
        }
    }
}