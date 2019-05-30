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
    public class ApplicationService : BaseService<Application, ApplicationModel>, IApplicationService
    {
        public ApplicationService(IMapper mapper, IApplicationRepository repository) : base(mapper, repository)
        {
        }
    }
}