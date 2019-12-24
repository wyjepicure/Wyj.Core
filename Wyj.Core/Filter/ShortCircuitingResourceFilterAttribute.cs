using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Wyj.Core.Filter
{
    public class ShortCircuitingResourceFilterAttribute : Attribute,
        IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
           
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            context.Result = new ContentResult()
            {
                Content = "短路了"
            };
        }
    }
}
