﻿using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity> AddAsync(TEntity entity);
        TEntity Add(TEntity entity);

        Task AddRangeAsync(IEnumerable<TEntity> entities);

        void AddRange(IEnumerable<TEntity> entities);
        Task<TEntity> UpdateAsync(TEntity entity);
        TEntity Update(TEntity entity);

        Task<TEntity> DeleteAsync(Guid integrationId);

        TEntity Delete(Guid integrationId);

        Task<IEnumerable<TEntity>> GetAllAsync();
        IEnumerable<TEntity> GetAll();

        TEntity FindById(Guid integrationId);

        IQueryable<TEntity> ListAsQueryable();

        Task<TEntity> FindByIdAsync(Guid integrationId);


    }
}
