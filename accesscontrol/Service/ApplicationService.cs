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
        public ApplicationService(IMapper mapper, IApplicationRepository repository) : base(mapper, repository)
        {
        }

        public async Task<ApplicationModel> AddAsync(ApplicationModel model)
        {
            var Application = this._mapper.Map<Application>(model);
            var entity = await this._repository.AddAsync(Application);
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            await this._repository.DeleteAsync(id);
        }

        public async Task<ApplicationModel> GetByIdAsync(int id)
        {
            return await this._repository.GetByIdAsync(id);
        }

        public async Task<List<ApplicationModel>> ListAsync()
        {
            return await this._repository.ListAsync();
        }

        public async Task UpdateAsync(int id, ApplicationModel model)
        {
            var application = this._mapper.Map<Application>(model);
            application.Id = id;
            await this._repository.UpdateAsync(application);
        }
    }
}