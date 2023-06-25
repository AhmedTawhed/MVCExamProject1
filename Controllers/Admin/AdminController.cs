using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCExamProject.Repository;
using MVCExamProject.Repository.Interfaces;

namespace MVCExamProject.Controllers.Admin
{
    public class AdminController : Controller
    {
        private IAdminRepository adminService;

        public AdminController
        (
           IAdminRepository _adminService
        )
        {
            adminService = _adminService;
        }

        [Route("admin/login")]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }
			return View("~/Views/Admin/Auth/Login.cshtml");
		}

    }
}
