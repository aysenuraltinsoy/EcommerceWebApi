using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Filters
{
    public class ValidationFilter : IAsyncActionFilter //The filter that is activated in requests to the action
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors=context.ModelState
                    .Where(x=>x.Value.Errors.Any())
                    .ToDictionary(e=>e.Key, e=>e.Value.Errors.Select(e=>e.ErrorMessage)).ToArray();

                context.Result = new BadRequestObjectResult(errors);
                return;
            }
            await next();
        }
    }
}
