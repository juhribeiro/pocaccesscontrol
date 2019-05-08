using System.Collections.Generic;
using System.Threading.Tasks;
using accesscontrol.Data;
using accesscontrol.Model;
using accesscontrol.Repository.Base;
using accesscontrol.Services.Base;
using AutoMapper;

namespace accesscontrol.Service
{
    public class GroupService : BaseService<Group, GroupModel>, IGroupService
    {
        public GroupService(IMapper mapper, IBaseRepository<Group, GroupModel> repository) : base(mapper, repository)
        {
        }

        public async Task<GroupModel> AddAsync(GroupModel model)
        {
            var Group = this._mapper.Map<Group>(model);
            var entity = await this._repository.AddAsync(Group);
            return entity;
        }

        public Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<GroupModel> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<GroupModel>> ListAsync()
        {
            return await this._repository.ListAsync();
        }

        public Task UpdateAsync(int id, GroupModel entity)
        {
            throw new System.NotImplementedException();
        }
    }
}