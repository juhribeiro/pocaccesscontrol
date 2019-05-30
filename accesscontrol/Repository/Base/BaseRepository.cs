using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using accesscontrol.Data;
using accesscontrol.ExceptionMiddleware;
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

        public virtual Task<List<T2>> ListAsync(bool active)
        {
            return this._dbContext.Set<T1>().ProjectTo<T2>(_mapper).Where(x => x.Active == active).ToListAsync();
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
            if (entity is null)
            {
                throw new CustomException(new MessageDetails(Enums.MessageType.Warning, $"Sorry, but not found Id {id}"));
            }

            this._dbContext.Set<T1>().Remove(entity);
            await this._dbContext.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(T1 entity)
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

        public async Task<Application> GetApplication(int ApplicationId)
        {
            var app = await this._dbContext.Applications.FirstOrDefaultAsync(x => x.Id.Equals(ApplicationId));
            if (app is null)
            {
                throw new CustomException(new MessageDetails(Enums.MessageType.Error, $"Sorry, but not found applicationId {ApplicationId}"));
            }

            return app;
        }

        public async Task<User> GetUser(int userId)
        {
            var user = await this._dbContext.Users.FirstOrDefaultAsync(x => x.Id.Equals(userId));
            if (user is null)
            {
                throw new CustomException(new MessageDetails(Enums.MessageType.Error, $"Sorry, but not found userId {userId}"));
            }

            return user;
        }

        public async Task<Group> GetGroup(int groupId)
        {
            var group = await this._dbContext.Groups.FirstOrDefaultAsync(x => x.Id.Equals(groupId));
            if (group is null)
            {
                throw new CustomException(new MessageDetails(Enums.MessageType.Error, $"Sorry, but not found groupId {groupId}"));
            }

            return group;
        }

        public async Task<Role> GetRole(int roleId)
        {
            var role = await this._dbContext.Roles.FirstOrDefaultAsync(x => x.Id.Equals(roleId));
            if (role is null)
            {
                throw new CustomException(new MessageDetails(Enums.MessageType.Error, $"Sorry, but not found roleId {roleId}"));
            }

            return role;
        }
    }
}