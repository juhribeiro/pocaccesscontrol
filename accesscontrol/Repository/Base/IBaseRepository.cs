using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using accesscontrol.Data;
using accesscontrol.Model;

namespace accesscontrol.Repository.Base
{
    public interface IBaseRepository<T1, T2> where T1 : BaseEntity where T2 : BaseModel
    {
        Task<T2> GetByIdAsync(int id);
        Task<List<T2>> ListAsync(bool active);
        Task<T2> AddAsync(T1 entity);
        Task UpdateAsync(T1 entity);
        Task DeleteAsync(int id);
        Task<List<T2>> ListByConditionAsync(Expression<Func<T1, bool>> expression);
        Task<T2> GetByConditionAsync(Expression<Func<T1, bool>> expression);

    }
}