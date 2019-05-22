using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using accesscontrol.Data;
using accesscontrol.Model;
using accesscontrol.Util;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace accesscontrol.Repository.Base
{
    public class BaseRepository<T1, T2> : IBaseRepository<T1, T2> where T1 : BaseEntity where T2 : BaseModel
    {
        public readonly ACContext _dbContext;
        public readonly IMapper _mapper;

        public BaseRepository(ACContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }

        public Task<T2> GetByIdAsync(int id)
        {
            return this._dbContext.Set<T1>().ProjectTo<T2>(_mapper).SingleOrDefaultAsync(e => e.Id == id);
        }

        public Task<List<T2>> ListAsync()
        {
            return this._dbContext.Set<T1>().ProjectTo<T2>(_mapper).ToListAsync();
        }

        public virtual async Task<T2> AddAsync(T1 entity)
        {
            await this._dbContext.Set<T1>().AddAsync(entity);
            await this._dbContext.SaveChangesAsync();

            return this._mapper.Map<T2>(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await this._dbContext.Set<T1>().SingleOrDefaultAsync(e => e.Id == id);
            this._dbContext.Set<T1>().Remove(entity);
            await this._dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T1 entity)
        {
            this._dbContext.Entry(entity).State = EntityState.Modified;
            await this._dbContext.SaveChangesAsync();
        }

        public async Task<List<T2>> ListByConditionAsync(Expression<Func<T1, bool>> expression)
        {
            var entities = await this._dbContext.Set<T1>().Where(expression).ToListAsync();
            return this._mapper.Map<List<T2>>(entities);
        }

        public async Task<T2> GetByConditionAsync(Expression<Func<T1, bool>> expression)
        {
            var entity = await this._dbContext.Set<T1>().FirstOrDefaultAsync(expression);
            return this._mapper.Map<T2>(entity);
        }
    }
}