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
    }
}