using System.Threading.Tasks;
using accesscontrol.Model;
using accesscontrol.Services.Base;

namespace accesscontrol.Service
{
    public interface IApplicationService : IBaseService<ApplicationModel>
    {
        Task<RegisterApplicationModel> RegisterAsync(RegisterApplicationModel model);
    }
}