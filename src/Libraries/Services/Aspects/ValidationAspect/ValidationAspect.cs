using Microsoft.AspNetCore.Mvc.Filters;
using Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Aspects.ValidationAspect
{
    [Serializable]
    public class ValidationAspect : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }


        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new ValidationFailedResult(context.ModelState);
            }
        }
    }
}
