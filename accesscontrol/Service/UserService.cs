using System.Collections.Generic;
using System.Linq;
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
        private readonly IUserRepository userRepository;

        public UserService(IMapper mapper, IUserRepository repository) : base(mapper, repository)
        {
            this.userRepository = repository;
        }

        public async Task<List<UserModel>> GetByGroupIdAsync(int groupId)
        {
            return await this.userRepository.GetByGroupIdAsync(groupId);
        }

        public async Task<List<UserModel>> GetByApplicationIdAsync(int applicationId)
        {
            return await this.userRepository.GetByApplicationIdAsync(applicationId);
        }
    }
}