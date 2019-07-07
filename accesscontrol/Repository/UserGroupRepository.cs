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

        public override async Task<UserGroupModel> AddAsync(UserGroup entity)
        {
            entity.Group = await this.GetGroup(entity.GroupId);
            entity.User = await this.GetUser(entity.UserId);
            return await base.AddAsync(entity);
        }

        public override async Task UpdateAsync(UserGroup entity)
        {
            entity.Group = await this.GetGroup(entity.GroupId);
            entity.User = await this.GetUser(entity.UserId);
            await base.UpdateAsync(entity);
        }
    }
}