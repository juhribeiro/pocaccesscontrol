using accesscontrol.Model;
using accesscontrol.Service;
using accesscontrol.Services.Base;

namespace accesscontrol.Controllers
{
    public class ApplicationController : BaseController<ApplicationModel>
    {
        public ApplicationController(ApplicationService service) : base(service)
        {
        }
    }
}