using accesscontrol.Data;
using accesscontrol.Model;
using accesscontrol.Repository.Base;
using AutoMapper;

namespace accesscontrol.Repository
{
    public class RoleRepository : BaseRepository<Role, RoleModel>, IRoleRepository
    {
        public RoleRepository(ACContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}