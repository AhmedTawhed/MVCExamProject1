using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MVCExamProject.Controllers.Admin
{
	public class MessageController : Controller
	{

		//[Authorize("Admin")]
		[Route("admin/messages")]
		public IActionResult Index()
		{
			return View("~/Views/Admin/Message/index.cshtml");
		}
	}
}
