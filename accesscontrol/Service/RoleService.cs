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
    public class RoleService : BaseService<Role, RoleModel>, IRoleService
    {
        public RoleService(IMapper mapper, IRoleRepository repository) : base(mapper, repository)
        {
        }

        public async Task<RoleModel> AddAsync(RoleModel model)
        {
            var role = this._mapper.Map<Role>(model);
            var entity = await this._repository.AddAsync(role);
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            await this._repository.DeleteAsync(id);
        }

        public async Task<RoleModel> GetByIdAsync(int id)
        {
            return await this._repository.GetByIdAsync(id);
        }

        public async Task<List<RoleModel>> ListAsync()
        {
            return await this._repository.ListAsync();
        }

        public async Task UpdateAsync(int id, RoleModel model)
        {
            var role = this._mapper.Map<Role>(model);
            role.Id = id;
            await this._repository.UpdateAsync(role);
        }
    }
}