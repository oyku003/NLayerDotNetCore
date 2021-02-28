using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyNLayerProject.API.DTOs;
using UdemyNLayerProject.Core.Services;

namespace UdemyNLayerProject.API.Filters
{
    public class NotFoundFilter :ActionFilterAttribute
    {
        private readonly IProductService productService;

        public NotFoundFilter(IProductService productService)//bu class dı aldığı için öncelikle startupa scope ekledik ve cagırılan yerde de servisfilter ile çağırdık
        {
            this.productService = productService;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault();

            var product = await productService.GetByIdAsync(id);

            if (product != default(Product))
            {
                await next();
            }
            else
            {
                var errorDto = new ErrorDto
                {
                    Status = 404
                };
                errorDto.Errors.Add($"Id'si {id} olan ürün veritabanında bulunamadı");

                context.Result = new NotFoundObjectResult(errorDto);
            }
        }
    }
}
