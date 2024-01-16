﻿using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class Repository<TEntity> : IDisposable, IRepository<TEntity> where TEntity : Entity
    {
        private readonly PdvContext _context;

        public Repository(PdvContext context)
        {
            _context = context;
        }

        public TEntity Add(TEntity entity)
        {
            var result = _context.Set<TEntity>().Add(entity);

            return result.Entity;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            return (await _context.Set<TEntity>().AddAsync(entity)).Entity;
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }

        public async Task<TEntity> DeleteAsync(Guid integrationId)
        {
            var entity = await _context
                .Set<TEntity>()
                .FirstOrDefaultAsync(x => x.IntegrationId == integrationId);

            return _context.Set<TEntity>().Remove(entity).Entity;
        }

        public TEntity Delete(Guid integrationId)
        {
            var entity = _context
                .Set<TEntity>()
                .FirstOrDefault(x => x.IntegrationId == integrationId);

            return _context
                .Set<TEntity>()
                .Remove(entity).Entity;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>()
            .ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>()
                .ToListAsync();
        }

        public TEntity FindById(Guid integrationId)
        {
            var result = _context
                .Set<TEntity>()
                .FirstOrDefault(x => x.IntegrationId == integrationId);

            return result;
        }

        public async Task<TEntity> FindByIdAsync(Guid integrationId)
        {
            var result = await _context
                .Set<TEntity>()
                .FirstOrDefaultAsync(x => x.IntegrationId == integrationId);

            return result;
        }

        public TEntity Update(TEntity entity)
        {
            var e = _context.Set<TEntity>().FirstOrDefault(x => x.IntegrationId == entity.IntegrationId);

            entity.Id = e.Id;

            _context.DetachLocal<TEntity>(entity, e.Id);

            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var e = await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.IntegrationId == entity.IntegrationId);

            entity.Id = e.Id;

            _context.DetachLocal<TEntity>(entity, e.Id);

            return entity;
        }

        public IQueryable<TEntity> ListAsQueryable()
        {
            return _context.Set<TEntity>();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
