using accesscontrol.Data;
using accesscontrol.Model;
using accesscontrol.Repository.Base;
using AutoMapper;

namespace accesscontrol.Repository
{
    public class UserApplicationRepository : BaseRepository<UserApplication, UserApplicationModel>, IUserApplicationRepository
    {
        public UserApplicationRepository(ACContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}