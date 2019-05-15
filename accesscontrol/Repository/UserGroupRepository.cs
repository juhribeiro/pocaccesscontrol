using System.Linq;
using System.Threading.Tasks;
using accesscontrol.Data;
using Microsoft.EntityFrameworkCore;

namespace accesscontrol.Repository
{
    public class UserGroupRepository : IUserGroupRepository
    {
        private readonly ACContext dbContext;

        public UserGroupRepository(ACContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<UserGroup> GetUserGroupByEmailAsync(string email)
        {
            return await this.dbContext.UserGroups.Include(x => x.User)
            .Include(x => x.Group).ThenInclude(x => x.RoleGroups)
            .ThenInclude(x => x.Role).FirstOrDefaultAsync(x => x.User.Email.Equals(email));
        }
    }
}