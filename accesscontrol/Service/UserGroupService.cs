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
    public class UserGroupService : BaseService<UserGroup, UserGroupModel>, IUserGroupService
    {
        public UserGroupService(IMapper mapper, IUserGroupRepository repository) : base(mapper, repository)
        {
        }

        public async Task<UserGroupModel> AddAsync(UserGroupModel model)
        {
            var userapp = this._mapper.Map<UserGroup>(model);
            var entity = await this._repository.AddAsync(userapp);
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            await this._repository.DeleteAsync(id);
        }

        public async Task<UserGroupModel> GetByIdAsync(int id)
        {
            return await this._repository.GetByIdAsync(id);
        }

        public async Task<List<UserGroupModel>> ListAsync()
        {
            return await this._repository.ListAsync();
        }

        public async Task UpdateAsync(int id, UserGroupModel model)
        {
            var role = this._mapper.Map<UserGroup>(model);
            role.Id = id;
            await this._repository.UpdateAsync(role);
        }
    }
}