using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UdemyNLayerProject.Core.Repositories;

namespace UdemyNLayer.Data.Repositories
{
    internal class ProductRepository : Repository<Product>, IProductRepository
    {
        private AppDbContext appDbContext { get => dbContext as AppDbContext; }//bunu yapmasaydık ilgili entityler için aşağıdaki ef sorgusu calışmayacaktı
        public ProductRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            return await appDbContext.Products.Include(x => x.Category).SingleOrDefaultAsync(x=>x.Id == productId);
        }
    }
}
