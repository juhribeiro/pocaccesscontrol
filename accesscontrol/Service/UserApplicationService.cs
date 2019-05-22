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
    public class UserApplicationService : BaseService<UserApplication, UserApplicationModel>, IUserApplicationService
    {
        public UserApplicationService(IMapper mapper, IUserApplicationRepository repository) : base(mapper, repository)
        {
        }

        public async Task<UserApplicationModel> AddAsync(UserApplicationModel model)
        {
            var userapp = this._mapper.Map<UserApplication>(model);
            var entity = await this._repository.AddAsync(userapp);
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            await this._repository.DeleteAsync(id);
        }

        public async Task<UserApplicationModel> GetByIdAsync(int id)
        {
            return await this._repository.GetByIdAsync(id);
        }

        public async Task<List<UserApplicationModel>> ListAsync()
        {
            return await this._repository.ListAsync();
        }

        public async Task UpdateAsync(int id, UserApplicationModel model)
        {
            var role = this._mapper.Map<UserApplication>(model);
            role.Id = id;
            await this._repository.UpdateAsync(role);
        }
    }
}