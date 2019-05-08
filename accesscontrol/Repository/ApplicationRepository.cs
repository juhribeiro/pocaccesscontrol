using accesscontrol.Data;
using accesscontrol.Model;
using accesscontrol.Repository.Base;
using AutoMapper;

namespace accesscontrol.Repository
{
    public class ApplicationRepository : BaseRepository<Application, ApplicationModel>, IApplicationRepository
    {
        public ApplicationRepository(ACContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}