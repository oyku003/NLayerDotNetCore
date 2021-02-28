using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyNLayerProject.API.DTOs;

namespace UdemyNLayerProject.API.Extension
{
    public static class UseCustomExceptionHandler//objelerin üzerine yazdıgımız ekstra metotlar extension metotlardır ve static olmalılardır.
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(options =>
            {
                options.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";
                    var error = context.Features.Get<IExceptionHandlerFeature>();//uyg içinde hata fırladığında burası yakalar

                    if (error != null)
                    {
                        var ex = error.Error;

                        var errorDto = new ErrorDto
                        {
                            Status = 500
                        };
                        errorDto.Errors.Add(ex.Message);

                        await context.Response.WriteAsync(JsonConvert.SerializeObject(errorDto));
                    }
                });
            });
        }
    }
}
