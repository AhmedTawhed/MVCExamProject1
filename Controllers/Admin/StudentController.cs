using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCExamProject.Models;
using MVCExamProject.Repository.Interfaces;


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
			return View("~/Views/Admin/Students/Index.cshtml", students);
		}

		//getbyid
		public IActionResult viewDetails(int id)
		{
			User student = _userRepository.GetById(id);
			return View(student);
		}

		//[Authorize("Admin")]
		[Route("admin/students/delete")]
		public IActionResult Delete(int id)
		{
			User student = _userRepository.GetById(id);

			if (student != null)
			{

				_userRepository.Delete(student);


			}
			return View("~/Views/Admin/students/index.cshtml");
		}

	}
}
