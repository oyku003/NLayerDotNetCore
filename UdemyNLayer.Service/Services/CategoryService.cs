using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UdemyNLayerProject.Core.Repositories;
using UdemyNLayerProject.Core.Services;
using UdemyNLayerProject.Core.UnitOfWorks;

namespace UdemyNLayer.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IRepository<Category> repository) : base(unitOfWork, repository)
        {

        }
        public async Task<Category> GetWithProductsByIdAsync(int categoryId)
        {
            return await unitOfWork.Categories.GetWithProductsByIdAsync(categoryId);
        }
    }
}
