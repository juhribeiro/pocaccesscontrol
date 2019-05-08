using System.Collections.Generic;
using System.Threading.Tasks;
using accesscontrol.Data;
using accesscontrol.Model;
using accesscontrol.Repository.Base;
using accesscontrol.Services.Base;
using AutoMapper;

namespace accesscontrol.Service
{
    public class RoleService : BaseService<Role, RoleModel>, IRoleService
    {
        public RoleService(IMapper mapper, IBaseRepository<Role, RoleModel> repository) : base(mapper, repository)
        {
        }

        public async Task<RoleModel> AddAsync(RoleModel model)
        {
            var Role = this._mapper.Map<Role>(model);
            var entity = await this._repository.AddAsync(Role);
            return entity;
        }

        public Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<RoleModel> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<RoleModel>> ListAsync()
        {
            return await this._repository.ListAsync();
        }

        public Task UpdateAsync(int id, RoleModel entity)
        {
            throw new System.NotImplementedException();
        }
    }
}