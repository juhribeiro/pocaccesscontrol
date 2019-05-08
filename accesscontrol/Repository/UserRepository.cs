using accesscontrol.Data;
using accesscontrol.Model;
using accesscontrol.Repository.Base;
using AutoMapper;

namespace accesscontrol.Repository
{
    public class UserRepository : BaseRepository<User, UserModel>, IUserRepository
    {
        public UserRepository(ACContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}