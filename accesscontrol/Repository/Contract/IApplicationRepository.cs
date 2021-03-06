using System.Threading.Tasks;
using accesscontrol.Data;
using accesscontrol.Model;
using accesscontrol.Repository.Base;

namespace accesscontrol.Repository
{
    public interface IApplicationRepository : IBaseRepository<Application, ApplicationModel>
    {
        Task<ApplicationModel> RegisterAsync(Application entity);
    }
}