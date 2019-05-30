using System.Threading.Tasks;
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

        public override async Task<UserApplicationModel> AddAsync(UserApplication entity)
        {
            entity.Application = await this.GetApplication(entity.ApplicationId);
            entity.User = await this.GetUser(entity.UserId);
            return await base.AddAsync(entity);
        }

        public override async Task UpdateAsync(UserApplication entity)
        {
            entity.Application = await this.GetApplication(entity.ApplicationId);
            entity.User = await this.GetUser(entity.UserId);
            await base.UpdateAsync(entity);
        }
    }
}