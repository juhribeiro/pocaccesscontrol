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
    public class RoleService : BaseService<Role, RoleModel>, IRoleService
    {
        public RoleService(IMapper mapper, IRoleRepository repository) : base(mapper, repository)
        {
        }
    }
}