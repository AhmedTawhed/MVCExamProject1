using Microsoft.AspNetCore.Mvc;

namespace MVCExamProject.Controllers.Admin
{
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
