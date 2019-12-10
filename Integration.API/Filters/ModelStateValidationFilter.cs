using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration.API.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace Integration.API.Filters
{
    public class ModelStateValidationFilter : IAsyncActionFilter
    {
        private IWebHostEnvironment _webHostEnvironment;
        private List<ErrorResponse> _errors;

        public ModelStateValidationFilter(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }


        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.ModelState.IsValid)
            {
                await next();
                return;
            }

            _errors = new List<ErrorResponse>();

            foreach (var item in context.ModelState)
            {
                if (item.Value.ValidationState == ModelValidationState.Valid)
                    continue;

                var error = new ErrorResponse
                {
                    Code = item.Key,
                    Message = item.Value.Errors.FirstOrDefault()?.ErrorMessage
                };

                _errors.Add(error);
            }

            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.HttpContext.Response.ContentType = "application/json";

            await context.HttpContext.Response.WriteAsync(JsonConvert.SerializeObject(_errors));
        }
    }
}