using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyNLayerProject.Web.ApiService;
using UdemyNLayerProject.Web.DTOs;

namespace UdemyNLayerProject.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly CategoryApiService categoryApiService;
        public CategoriesController( CategoryApiService categoryApiService)
        {
            this.categoryApiService = categoryApiService;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await categoryApiService.GetAllAsync();

            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            await categoryApiService.AddAsync(categoryDto);

            return RedirectToAction("Index");
        }
    }
}
