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
    public class GroupService : BaseService<Group, GroupModel>, IGroupService
    {
        public GroupService(IMapper mapper, IGroupRepository repository) : base(mapper, repository)
        {
        }

        public async Task<GroupModel> AddAsync(GroupModel model)
        {
            var group = this._mapper.Map<Group>(model);
            var entity = await this._repository.AddAsync(group);
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            await this._repository.DeleteAsync(id);
        }

        public async Task<GroupModel> GetByIdAsync(int id)
        {
            return await this._repository.GetByIdAsync(id);
        }

        public async Task<List<GroupModel>> ListAsync()
        {
            return await this._repository.ListAsync();
        }

        public async Task UpdateAsync(int id, GroupModel model)
        {
            var group = this._mapper.Map<Group>(model);
            group.Id = id;
            await this._repository.UpdateAsync(group);
        }
    }
}