using accesscontrol.Data;
using accesscontrol.Model;
using accesscontrol.Repository.Base;
using AutoMapper;

namespace accesscontrol.Services.Base
{
    public class BaseService<T1, T2> where T1 : BaseEntity where T2 : BaseModel
    {
        protected readonly IBaseRepository<T1,T2> _repository;
        protected readonly IMapper _mapper;

        public BaseService(IMapper mapper, IBaseRepository<T1,T2> repository)
        {
            this._mapper = mapper;
            this._repository = repository;
        }
    }
}