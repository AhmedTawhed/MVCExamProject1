using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace MVCExamProject.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class StudentController : Controller
    {
        //[Authorize("Admin")]
        [Route("admin/students")]
        public IActionResult Index()
        {

            return View("~/Views/Admin/Student/index.cshtml");
        }

        //[Authorize("Admin")]
        [Route("admin/students/show")]
		public IActionResult Show(int id)
		{

			return View("~/Views/Admin/Student/Show.cshtml");
		}
	}
}
