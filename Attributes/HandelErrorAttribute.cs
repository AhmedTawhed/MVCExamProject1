using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.FileProviders.Physical;

namespace MVCExamProject.Attributes
{
	public class HandelErrorAttribute : Attribute, IExceptionFilter
	{
		public void OnException(ExceptionContext context)
		{
			
		}
	}
}
