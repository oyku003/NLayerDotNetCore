﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UdemyNLayerProject.Core.Repositories;
using UdemyNLayerProject.Core.Services;
using UdemyNLayerProject.Core.UnitOfWorks;

namespace UdemyNLayer.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork, IRepository<Product> repository) : base(unitOfWork, repository)
        {

        }
        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            return await unitOfWork.Products.GetWithCategoryByIdAsync(productId);
        }
    }
}
