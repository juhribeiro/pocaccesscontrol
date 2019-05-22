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
    }
}