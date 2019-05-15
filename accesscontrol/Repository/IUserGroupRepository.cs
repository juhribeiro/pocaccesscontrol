using System.Threading.Tasks;
using accesscontrol.Data;
using accesscontrol.Model;
using accesscontrol.Repository.Base;

namespace accesscontrol.Repository
{
    public interface IUserGroupRepository
    {
        Task<UserGroup> GetUserGroupByEmailAsync(string email);
    }
}