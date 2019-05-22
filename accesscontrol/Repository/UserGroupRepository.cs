using System.Linq;
using System.Threading.Tasks;
using accesscontrol.Data;
using accesscontrol.Model;
using accesscontrol.Repository.Base;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace accesscontrol.Repository
{
    public class UserGroupRepository : BaseRepository<UserGroup, UserGroupModel>, IUserGroupRepository
    {
         public UserGroupRepository(ACContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        
        public async Task<UserGroup> GetUserGroupByEmailAsync(string email)
        {
            return await this._dbContext.UserGroups.Include(x => x.User)
            .Include(x => x.Group).ThenInclude(x => x.RoleGroups)
            .ThenInclude(x => x.Role).FirstOrDefaultAsync(x => x.User.Email.Equals(email));
        }
    }
}