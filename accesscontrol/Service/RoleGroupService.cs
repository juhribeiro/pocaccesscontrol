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
    }
}