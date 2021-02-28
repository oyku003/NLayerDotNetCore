using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyNLayerProject.API.DTOs;
using UdemyNLayerProject.API.Filters;
using UdemyNLayerProject.Core.Services;

namespace UdemyNLayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;
        public ProductsController(IProductService categoryService, IMapper mapper)
        {
            this.productService = categoryService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            throw new Exception("Bir hata meydana geldi");
            var products = await productService.GetAllAsync();
            return Ok(mapper.Map<IEnumerable<ProductDto>>(products));
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await productService.GetByIdAsync(id);

            return Ok(mapper.Map<ProductDto>(product));
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpGet("{id}/category")]
        public async Task<IActionResult> GetWithCategoryById(int id)
        {
            var product = await productService.GetWithCategoryByIdAsync(id);

            return Ok(mapper.Map<ProductWithCategory>(product));
        }

        [ValidationFilter]
        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var newProduct = await productService.AddAsync(mapper.Map<Product>(productDto));

            return Created(string.Empty, mapper.Map<ProductDto>(newProduct));
        }

        [HttpPut]
        public IActionResult Update(ProductDto productDto)
        {
            var product = productService.Update(mapper.Map<Product>(productDto));

            return NoContent();
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var product = productService.GetByIdAsync(id).Result;
            productService.Remove(product);

            return NoContent();
        }
    }
}
