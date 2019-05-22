using System.Collections.Generic;
using System.Threading.Tasks;
using accesscontrol.Model;

namespace accesscontrol.Services.Base
{
    public interface IBaseService<T> where T : BaseModel
    {
        Task<T> AddAsync(T model);
        Task<T> GetByIdAsync(int id);
        Task<List<T>> ListAsync();
        Task UpdateAsync(int id, T model);
        Task DeleteAsync(int id);
    }
}