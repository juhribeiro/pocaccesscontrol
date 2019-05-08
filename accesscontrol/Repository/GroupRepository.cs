using accesscontrol.Data;
using accesscontrol.Model;
using accesscontrol.Repository.Base;
using AutoMapper;

namespace accesscontrol.Repository
{
    public class GroupRepository : BaseRepository<Group, GroupModel>, IGroupRepository
    {
        public GroupRepository(ACContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}