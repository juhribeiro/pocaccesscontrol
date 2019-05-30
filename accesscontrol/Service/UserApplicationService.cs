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
    }
}