using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using accesscontrol.Data;
using accesscontrol.Model;
using accesscontrol.Repository.Base;
using accesscontrol.Util;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace accesscontrol.Repository
{
    public class UserRepository : BaseRepository<User, UserModel>, IUserRepository
    {
        public UserRepository(ACContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override async Task<List<UserModel>> ListAsync(bool active)
        {
            return await this.ListByConditionAsync(x => !x.Email.Equals(SeedData.PrincipalEmail) && x.Active == active);
        }

        public async Task<List<UserModel>> GetByGroupIdAsync(int groupId)
        {
            var users = await this._dbContext.UserGroups.Include(x => x.User)
            .Where(x => x.Group.Id.Equals(groupId)).ToListAsync();

            return this._mapper.Map<List<UserModel>>(users.Select(x => x.User));
        }

        public async Task<List<UserModel>> GetByApplicationIdAsync(int applicationId)
        {
            var users = await this._dbContext.UserApplications.Include(x => x.User)
            .Where(x => x.Application.Id.Equals(applicationId)).ToListAsync();

            return this._mapper.Map<List<UserModel>>(users.Select(x => x.User));
        }
    }
}