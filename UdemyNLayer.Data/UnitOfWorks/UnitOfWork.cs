using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UdemyNLayer.Data.Repositories;
using UdemyNLayerProject.Core.Repositories;
using UdemyNLayerProject.Core.UnitOfWorks;

namespace UdemyNLayer.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext appDbContext;

        private ProductRepository productRepository;
        private CategoryRepository categoryRepository;
        public IProductRepository Products => productRepository = productRepository?? new ProductRepository(appDbContext);

        public ICategoryRepository Categories => categoryRepository = categoryRepository ?? new CategoryRepository(appDbContext);

        public UnitOfWork(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public void Commit()
        {
            appDbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await appDbContext.SaveChangesAsync();
        }
    }
}
