using System.Threading.Tasks;
using accesscontrol.Data;
using accesscontrol.ExceptionMiddleware;
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
            var app = await this._dbContext.Applications.FirstOrDefaultAsync(x => x.Code.Equals(entity.Application.Code));
            if (app is null)
            {
                throw new CustomException(new MessageDetails(Enums.MessageType.Error, $"Sorry, but not found application code {entity.Code}"));
            }

            entity.Application = this._mapper.Map<Application>(app);
            return await base.AddAsync(entity);
        }
    }
}