using Microsoft.AspNetCore.Mvc;
using MVCExamProject.Models;

namespace MVCExamProject.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult contactus()
        {
            return View();
        }


        [HttpPost]
        public IActionResult save(ContactUs contact)
        {
            if (ModelState.IsValid)
            {
                // Process the contact form submission (e.g., send an email)

                // Optionally, redirect to a "Thank You" page
                return RedirectToAction("ThankYou");
            }

            return View(contact);
        }

    }

}
