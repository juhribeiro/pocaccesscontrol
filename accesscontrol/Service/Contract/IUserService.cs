using System.Collections.Generic;
using System.Threading.Tasks;
using accesscontrol.Model;
using accesscontrol.Services.Base;

namespace accesscontrol.Service
{
    public interface IUserService : IBaseService<UserModel>
    {
         Task<List<UserModel>> GetByGroupIdAsync(int groupId);
         Task<List<UserModel>> GetByApplicationIdAsync(int applicationId);
    }
}