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
    }
}