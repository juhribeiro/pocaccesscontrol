using System.Collections.Generic;
using System.Threading.Tasks;
using accesscontrol.Data;
using accesscontrol.Model;
using accesscontrol.Repository.Base;
using accesscontrol.Services.Base;
using AutoMapper;

namespace accesscontrol.Service
{
    public class UserService : BaseService<User, UserModel>, IUserService
    {
        public UserService(IMapper mapper, IBaseRepository<User, UserModel> repository) : base(mapper, repository)
        {
        }

        public async Task<UserModel> AddAsync(UserModel model)
        {
            var user = this._mapper.Map<User>(model);
            var entity = await this._repository.AddAsync(user);
            return entity;
        }

        public Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserModel> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<UserModel>> ListAsync()
        {
            return await this._repository.ListAsync();
        }

        public Task UpdateAsync(int id, UserModel entity)
        {
            throw new System.NotImplementedException();
        }
    }
}