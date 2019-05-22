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
    public class RoleGroupService : BaseService<RoleGroup, RoleGroupModel>, IRoleGroupService
    {
        public RoleGroupService(IMapper mapper, IRoleGroupRepository repository) : base(mapper, repository)
        {
        }

        public async Task<RoleGroupModel> AddAsync(RoleGroupModel model)
        {
            var rolegroup = this._mapper.Map<RoleGroup>(model);
            var entity = await this._repository.AddAsync(rolegroup);
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            await this._repository.DeleteAsync(id);
        }

        public async Task<RoleGroupModel> GetByIdAsync(int id)
        {
            return await this._repository.GetByIdAsync(id);
        }

        public async Task<List<RoleGroupModel>> ListAsync()
        {
            return await this._repository.ListAsync();
        }

        public async Task UpdateAsync(int id, RoleGroupModel model)
        {
            var group = this._mapper.Map<RoleGroup>(model);
            group.Id = id;
            await this._repository.UpdateAsync(group);
        }
    }
}