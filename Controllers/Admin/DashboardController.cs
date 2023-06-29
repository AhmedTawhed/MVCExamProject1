using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCExamProject.Repository.Interfaces;

namespace MVCExamProject.Controllers.Admin
{
	public class DashboardController : Controller
	{

		private IContactUsRepository contactSerive;
		private IUserRepository userSerive;


		public DashboardController(IContactUsRepository _contactService, IUserRepository _userService)
		{
			contactSerive = _contactService;
			userSerive = _userService;
		}

		[Route("admin/dashboard")]
		//[Authorize("Admin")]
		public IActionResult Index()
		{
            return View("~/Views/Admin/Dashboard.cshtml");
        }
	}
}
