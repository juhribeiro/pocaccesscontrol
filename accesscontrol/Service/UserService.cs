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
    public class UserService : BaseService<User, UserModel>, IUserService
    {
        public UserService(IMapper mapper, IUserRepository repository) : base(mapper, repository)
        {
        }

        public async Task<UserModel> AddAsync(UserModel model)
        {
            var user = this._mapper.Map<User>(model);
            var entity = await this._repository.AddAsync(user);
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            await this._repository.DeleteAsync(id);
        }

        public async Task<UserModel> GetByIdAsync(int id)
        {
            return await this._repository.GetByIdAsync(id);
        }

        public async Task<List<UserModel>> ListAsync()
        {
            return await this._repository.ListAsync();
        }

        public async Task UpdateAsync(int id, UserModel model)
        {
            var role = this._mapper.Map<User>(model);
            role.Id = id;
            await this._repository.UpdateAsync(role);
        }
    }
}