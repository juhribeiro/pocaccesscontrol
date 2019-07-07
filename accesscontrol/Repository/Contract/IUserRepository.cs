using System.Collections.Generic;
using System.Threading.Tasks;
using accesscontrol.Data;
using accesscontrol.Model;
using accesscontrol.Repository.Base;

namespace accesscontrol.Repository
{
    public interface IUserRepository : IBaseRepository<User, UserModel>
    {
        Task<List<UserModel>> GetByGroupIdAsync(int groupId);
        Task<List<UserModel>> GetByApplicationIdAsync(int applicationId);
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByNumberGenerateAsync(int number);
    }
}