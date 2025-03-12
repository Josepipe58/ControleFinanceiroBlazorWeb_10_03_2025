﻿using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext _contexto;
        protected readonly DbSet<TEntity> DbSet;     
        public Repository(AppDbContext contexto)
        {
            _contexto = contexto;
            DbSet = _contexto.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> ObterTodosAsync()
        {
            if (_contexto is not null && DbSet is not null)
            {
                var listarTodos = await DbSet.AsNoTracking().ToListAsync();
                return listarTodos;
            }
            else
            {
                return [];
            }
        }

        public async Task<TEntity> GetByIdAsync(int? id)
        {
            var entity = await DbSet.FindAsync(id);
            return entity;
        }

        public async Task<TEntity> ObterPorIdAsync(int id)
        {
            var entity = await DbSet.FindAsync(id);

            return entity;
        }

        public async Task<TEntity> AdicionarAsync(TEntity entity)
        {
            if (_contexto is not null && DbSet is not null)
            {
                DbSet.Add(entity);
                await _contexto.SaveChangesAsync();

                return entity;
            }
            else
            {
                throw new InvalidOperationException(nameof(entity));
            }
        }

        public async Task<TEntity> EditarAsync(TEntity entity)
        {
            if (entity is not null)
            {
                DbSet.Entry(entity).State = EntityState.Modified;
                await _contexto.SaveChangesAsync();

                return entity;
            }
            else
            {
                throw new ArgumentNullException(nameof(entity));
            }
        }

        public async Task ExcluirAsync(int id)
        {
            var entity = await DbSet.FindAsync(id);
            DbSet.Remove(entity);
            await _contexto.SaveChangesAsync();
        }

        public void Dispose()
        {
            _contexto?.Dispose();
        }
    }
}
