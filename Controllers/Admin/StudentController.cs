using Microsoft.AspNetCore.Mvc;
using MVCExamProject.Repository.Interfaces;

namespace MVCExamProject.Controllers.Admin
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

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
