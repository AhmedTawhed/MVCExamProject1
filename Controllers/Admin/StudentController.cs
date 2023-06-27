<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Mvc;
using MVCExamProject.Repository.Interfaces;
=======
﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
>>>>>>> parent of 7346757 (Admin (authentication/validation/signout))

namespace MVCExamProject.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
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
