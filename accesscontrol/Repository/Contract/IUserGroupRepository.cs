using System.Threading.Tasks;
using accesscontrol.Data;
using accesscontrol.Model;
using accesscontrol.Repository.Base;

namespace accesscontrol.Repository
{
    public interface IUserGroupRepository : IBaseRepository<UserGroup, UserGroupModel>
    {
        Task<UserGroup> GetByEmailAsync(string email);
        Task<UserGroup> GetByNumberGenerateAsync(int number);
    }
}