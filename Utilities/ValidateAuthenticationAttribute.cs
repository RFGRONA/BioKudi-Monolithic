using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace BioKudi.Utilities
{
	// Attribute that checks if the user is logged in, if not redirects them to home
	public class ValidateAuthenticationAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			if (!context.HttpContext.User.Identity.IsAuthenticated)
			{
				context.Result = new RedirectToActionResult("Index", "Home", null);
			}

			base.OnActionExecuting(context);
		}
	}
}
