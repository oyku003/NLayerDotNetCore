using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UdemyNLayerProject.Core.Repositories;
using UdemyNLayerProject.Core.Services;
using UdemyNLayerProject.Core.UnitOfWorks;

namespace UdemyNLayer.Service
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        public readonly IUnitOfWork unitOfWork;
        private readonly IRepository<TEntity> repository;

        public Service(IUnitOfWork unitOfWork, IRepository<TEntity> repository)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await repository.AddAsync(entity);
            await unitOfWork.CommitAsync();

            return entity;
        }

        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await repository.AddRangeAsync(entities);
            await unitOfWork.CommitAsync();

            return entities;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await repository.GetByIdAsync(id);
        }

        public void Remove(TEntity entity)
        {
            repository.Remove(entity);
            unitOfWork.Commit();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            repository.RemoveRange(entities);
            unitOfWork.Commit();
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await repository.SingleOrDefaultAsync(predicate);
        }

        public TEntity Update(TEntity entity)
        {
            var updateEntity = repository.Update(entity);
            unitOfWork.Commit();

            return updateEntity;
        }

        public async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return await repository.Where(predicate);
        }
    }
}
