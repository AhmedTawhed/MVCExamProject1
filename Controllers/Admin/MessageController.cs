using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCExamProject.Models;
using MVCExamProject.Repository.Interfaces;
using System.Data;

namespace MVCExamProject.Controllers.Admin
{
    [Authorize(Roles = "Admin")]

    public class MessageController : Controller
	{
		private IContactUsRepository contactUsRepository;

		public MessageController(IContactUsRepository contactUsRepo)
		{
			contactUsRepository
				 = contactUsRepo;
		}


		//[Authorize("Admin")]
		[Route("admin/messages")]
		public IActionResult Index()
		{
			List<ContactUs> contactUsModel = contactUsRepository.GetAll();
			return View("~/Views/Admin/Message/index.cshtml", contactUsModel);
		}



		//[Authorize("Admin")]
		[Route("admin/messages/delete")]
		public IActionResult Delete(int id)
		{
			ContactUs mssg = contactUsRepository.GetById(id);

			if (mssg != null)
			{
				// Remove the course from the database
				contactUsRepository.Delete(mssg);
				//save????????????????

				List<ContactUs> contactUsModel = contactUsRepository.GetAll();
				return View("~/Views/Admin/Message/index.cshtml", contactUsModel);
			}
			return View("~/Views/Admin/Message/index.cshtml");
		}




	}
}
