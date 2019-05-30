using System.Threading.Tasks;
using accesscontrol.Data;
using accesscontrol.Model;
using accesscontrol.Repository.Base;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace accesscontrol.Repository
{
    public class GroupRepository : BaseRepository<Group, GroupModel>, IGroupRepository
    {
        public GroupRepository(ACContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override async Task<GroupModel> AddAsync(Group entity)
        {
            entity.Application = await this.GetApplication(entity.ApplicationId);
            return await base.AddAsync(entity);
        }

        public override async Task UpdateAsync(Group entity)
        {
            entity.Application = await this.GetApplication(entity.ApplicationId);
            await base.UpdateAsync(entity);
        }
    }
}