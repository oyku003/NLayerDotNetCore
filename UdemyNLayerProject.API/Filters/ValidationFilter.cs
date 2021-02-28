using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyNLayerProject.API.DTOs;

namespace UdemyNLayerProject.API.Filters
{
    public class ValidationFilter :ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)//request geldiğinde müdahale etmek için bu metodu override ettik
        {
            if (!context.ModelState.IsValid)
            {
                var errorDt = new ErrorDto
                {
                    Status = 400
                };

                IEnumerable<ModelError> modelErrors = context.ModelState.Values.SelectMany(x => x.Errors);

                modelErrors.ToList().ForEach(x =>
                {
                    errorDt.Errors.Add(x.ErrorMessage);
                });

                context.Result = new BadRequestObjectResult(errorDt);
            }
        }
    }
}
