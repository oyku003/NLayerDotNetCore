using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UdemyNLayerProject.Core.Services
{
    public interface IService<TEntity> where TEntity:class
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();

        //find(x=> x.ıd== id) herhangi bir parametreye göre nesneyi bul
        Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate);

        //category.SingleOrDefaultAsync(x=>x.name=="kalem")
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> AddAsync(TEntity entity);

        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);

        //delete metotları async olmaz
        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);

        TEntity Update(TEntity entity);
    }
}
