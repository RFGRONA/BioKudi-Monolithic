using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BioKudi.Utilities
{
	// Attribute that checks if the user is logged in and redirects them to the view corresponding to their role
	public class ValidateLoginAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			var role = context.HttpContext.User.FindFirst(ClaimTypes.Role)?.Value;

			if (role == "User")
			{
				context.Result = new RedirectToActionResult("IndexUser", "User",
					new { userId = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value });
				return;
			}

			if (role == "Admin")
			{
				context.Result = new RedirectToActionResult("IndexAdmin", "Admin",
					new { userId = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value });
				return;
			}

			base.OnActionExecuting(context);
		}
	}
}
