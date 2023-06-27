using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MVCExamProject.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class ExamController : Controller
    {

        //[Authorize("Admin")]
        [Route("admin/exams")]
        public IActionResult Index()
        {

            return View("~/Views/Admin/Exam/index.cshtml");
        }

        //[Authorize("Admin")]
        [HttpGet]
        [Route("admin/exams/create")]
        public IActionResult Create()
        {

            return View("~/Views/Admin/Exam/create.cshtml");
        }

    }
}
