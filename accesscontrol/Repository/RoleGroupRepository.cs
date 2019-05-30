using System.Threading.Tasks;
using accesscontrol.Data;
using accesscontrol.Model;
using accesscontrol.Repository.Base;
using AutoMapper;

namespace accesscontrol.Repository
{
    public class RoleGroupRepository : BaseRepository<RoleGroup, RoleGroupModel>, IRoleGroupRepository
    {
        public RoleGroupRepository(ACContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override async Task<RoleGroupModel> AddAsync(RoleGroup entity)
        {
            entity.Group = await this.GetGroup(entity.GroupId);
            entity.Role = await this.GetRole(entity.RoleId);
            return await base.AddAsync(entity);
        }

        public override async Task UpdateAsync(RoleGroup entity)
        {
            entity.Group = await this.GetGroup(entity.GroupId);
            entity.Role = await this.GetRole(entity.RoleId);
            await base.UpdateAsync(entity);
        }
    }
}