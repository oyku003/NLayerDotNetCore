using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UdemyNLayerProject.Core.Repositories;

namespace UdemyNLayer.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private AppDbContext appDbContext { get => dbContext as AppDbContext; }//bunu yapmasaydık ilgili entityler için aşağıdaki ef sorgusu calışmayacaktı

        public CategoryRepository(AppDbContext dbContext) :base(dbContext)
        {

        }
        public async Task<Category> GetWithProductsByIdAsync(int categoryId)
        {
            return await appDbContext.Categories.Include(x => x.Products).SingleOrDefaultAsync(x => x.Id == categoryId);
        }
    }
}
