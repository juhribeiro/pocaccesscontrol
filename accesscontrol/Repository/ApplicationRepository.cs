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
    public class ApplicationRepository : BaseRepository<Application, ApplicationModel>, IApplicationRepository
    {
        public ApplicationRepository(ACContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override async Task<List<ApplicationModel>> ListAsync(bool active)
        {
            return await this.ListByConditionAsync(x => !x.Code.Equals(SeedData.PrincipalApplication) && x.Active == active);
        }

        public async Task<ApplicationModel> RegisterAsync(Application entity)
        {
            var application = await this._dbContext.Applications.Include(x => x.Groups).ThenInclude(x => x.RoleGroups).ThenInclude(x => x.Role).SingleOrDefaultAsync(x => x.Code.Equals(entity.Code));
            if (application is null)
            {
                this.AddRolesToADM(ref entity);
                return await this.AddAsync(entity);
            }
            else
            {
                application.Groups.AddRange(entity.Groups);
                this.AddRolesToADM(ref application);
                await this.UpdateAsync(application);
            }

            return this._mapper.Map<ApplicationModel>(application);
        }

        private void AddRolesToADM(ref Application entity)
        {
            var group = this._dbContext.Groups.Include(x => x.RoleGroups).ThenInclude(x => x.Role).SingleOrDefault(x => x.Code.Equals(SeedData.AdmGroupCashAC));

            foreach (var item in entity.Groups.SelectMany(x => x.RoleGroups))
            {
                if (!group.RoleGroups.Any(x => x.Role.Code.Equals(item.Role.Code)))
                {
                    var rolesgroup = new RoleGroup
                    {
                        Role = item.Role,
                        Group = group
                    };

                    group.RoleGroups.Add(rolesgroup);
                }
            }

            entity.Groups.RemoveAll(x => string.IsNullOrEmpty(x.Code));
            if (!entity.Groups.Any(x => x.Code.Equals(SeedData.AdmGroupCashAC)))
            {
                entity.Groups.Add(group);
            }
        }
    }
}