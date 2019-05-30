using System.Collections.Generic;
using System.Threading.Tasks;
using accesscontrol.Data;
using accesscontrol.Model;
using accesscontrol.Repository.Base;
using accesscontrol.Util;
using AutoMapper;

namespace accesscontrol.Repository
{
    public class ApplicationRepository : BaseRepository<Application, ApplicationModel>, IApplicationRepository
    {
        public ApplicationRepository(ACContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override async Task<List<ApplicationModel>> ListAsync(bool active)
        {
            return await this.ListByConditionAsync(x => !x.Code.Equals(SeedData.PrincipalApplication) && x.Active == active);
        }
    }
}