using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace BioKudi.Utilities
{
    // This class is used to prevent the browser from caching the page
    public class NoCacheAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result is ViewResult)
            {
                context.HttpContext.Response.Headers["Cache-Control"] = "no-cache, no-store";
                context.HttpContext.Response.Headers["Pragma"] = "no-cache";
                context.HttpContext.Response.Headers["Expires"] = "-1";
            }

            base.OnActionExecuted(context);
        }
    }
}
