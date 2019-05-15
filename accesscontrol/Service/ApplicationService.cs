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
        public ApplicationService(IMapper mapper, ApplicationRepository repository) : base(mapper, repository)
        {
        }

        public async Task<ApplicationModel> AddAsync(ApplicationModel model)
        {
            var Application = this._mapper.Map<Application>(model);
            var entity = await this._repository.AddAsync(Application);
            return entity;
        }

        public Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ApplicationModel> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<ApplicationModel>> ListAsync()
        {
            return await this._repository.ListAsync();
        }

        public Task UpdateAsync(int id, ApplicationModel entity)
        {
            throw new System.NotImplementedException();
        }
    }
}