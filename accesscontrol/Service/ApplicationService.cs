using System.Collections.Generic;
using System.Threading.Tasks;
using accesscontrol.Data;
using accesscontrol.Model;
using accesscontrol.Repository;
using accesscontrol.Repository.Base;
using accesscontrol.Services.Base;
using AutoMapper;

namespace accesscontrol.Service
{
    public class ApplicationService : BaseService<Application, ApplicationModel>, IApplicationService
    {
        private readonly IApplicationRepository repository;

        public ApplicationService(IMapper mapper, IApplicationRepository repository) : base(mapper, repository)
        {
            this.repository = repository;
        }

        public async Task<RegisterApplicationModel> RegisterAsync(RegisterApplicationModel model)
        {
            var mappingapp = this._mapper.Map<Application>(model.Application);
            var group = new Group();
            var mappingroles = this._mapper.Map<List<Role>>(model.Roles);
            var rolesgroup = new List<RoleGroup>();
            foreach (var item in mappingroles)
            {
                var rg = new RoleGroup
                {
                    Group = group,
                    Role = item
                };

                rolesgroup.Add(rg);
            }

            group.RoleGroups.AddRange(rolesgroup);

            mappingapp.Groups.Add(group);
            var app = await this.repository.RegisterAsync(mappingapp);
            model.Application = app;
            return model;
        }
    }
}