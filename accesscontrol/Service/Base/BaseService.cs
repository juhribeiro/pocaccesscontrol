using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<T2> AddAsync(T2 model)
        {
            var document = this._mapper.Map<T1>(model);
            var entity = await this._repository.AddAsync(document);
            return entity;
        }

        public Task UpdateAsync(int id, T2 model)
        {
            var stub = this._mapper.Map<T1>(model);
            stub.Id = id;
            return this._repository.UpdateAsync(stub);
        }

        public async Task<List<T2>> ListAsync(bool active)
        {
            return await this._repository.ListAsync(active);
        }

        public Task<T2> GetByIdAsync(int id)
        {
            return this._repository.GetByIdAsync(id);
        } 

        public Task DeleteAsync(int id)
        {
            return this._repository.DeleteAsync(id);
        }  
    }
}