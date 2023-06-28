<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Mvc;
using MVCExamProject.Models;
using MVCExamProject.Repository.Interfaces;
﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
>>>>>>> parent of 7346757 (Admin (authentication/validation/signout))

namespace MVCExamProject.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class StudentController : Controller
    {
        private readonly IUserRepository _userRepository;

        public StudentController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


       
        //[Authorize("Admin")]
        [Route("admin/students")]
        public IActionResult Index()
        {
            List<User> students = _userRepository.GetAll();
            return View("~/Views/Admin/Student/index.cshtml", students);
        }

        //[Authorize("Admin")]
        [Route("admin/students/show")]
		public IActionResult Show(int id)
		{

			return View("~/Views/Admin/Student/Show.cshtml");
		}

        //[Authorize("Admin")]
        [Route("admin/students/delete")]
        public IActionResult Delete(int id)
        {
            User student = _userRepository.GetById(id);

            if (student != null)
            {
               
                _userRepository.Delete(student);
                //save????????????????

                List<User> students = _userRepository.GetAll();
                return View("~/Views/Admin/students/index.cshtml", students);
            }
            return View("~/Views/Admin/students/index.cshtml");
        }

    }
}
