using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyNLayerProject.API.DTOs;
using UdemyNLayerProject.Core.Services;

namespace UdemyNLayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;
        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            this.categoryService = categoryService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await categoryService.GetAllAsync();
            return Ok(mapper.Map<IEnumerable<CategoryDto>>(categories));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await categoryService.GetByIdAsync(id);

            return Ok(mapper.Map<CategoryDto>(category)); 
        }


        [HttpGet("{id}/products")]//idye sahip productları da getir
        public async Task<IActionResult> GetWithProductsById(int id)
        {
            var category = await categoryService.GetWithProductsByIdAsync(id);

            return Ok(mapper.Map<CategoryWithProductDto>(category));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CategoryDto categoryDto)
        {
          var newCategory =  await categoryService.AddAsync(mapper.Map<Category>(categoryDto));

            return Created(string.Empty, mapper.Map<CategoryDto>(newCategory));
        }

        [HttpPut]
        public IActionResult Update(CategoryDto categoryDto)
        {
            var category = categoryService.Update(mapper.Map<Category>(categoryDto));

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var category =  categoryService.GetByIdAsync(id).Result;
            categoryService.Remove(category);

            return NoContent();
        }

    }
}
