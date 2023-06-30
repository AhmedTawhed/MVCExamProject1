using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MVCExamProject.Data;
using MVCExamProject.Models;
using MVCExamProject.Repository.Interfaces;
using MVCExamProject.ViewModel;
using System.Security.Claims;

namespace MVCExamProject.Controllers
{
    public class UsersSignInController : Controller
    {
        ExamContext context;
        IUserRepository userRepository;
        public UsersSignInController(ExamContext _context, IUserRepository _userRepository)
        {
            context = _context;
            userRepository = _userRepository;

        }
        public IActionResult Sign_Up()
        {
            return View();
        }

		[HttpPost]
		public IActionResult Sign_Up(SignUPUserViewModel userVM)
		{
			User userdata=new User();

			userdata.Name = userVM.Name;
			userdata.Email = userVM.Email;
			userdata.Password = userVM.Password;
			userdata.Age = userVM.Age;
			//userdata.IsAdmin = userVM.IsAdmin;
			//userdata.UserExams= userVM.UserExams;
			User user3 = userRepository.GetByUserName(userVM.Name);
			if (user3 != null)
			{
				return Content("Username already taken");
			}
			else if (ModelState.IsValid)
			{

				userRepository.Insert(userdata);
				userRepository.Save();

				// create cookie
				ClaimsIdentity claims =
					new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
				claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, userdata.Id.ToString()));
				claims.AddClaim(new Claim(ClaimTypes.Name, userdata.Name));
				claims.AddClaim(new Claim(ClaimTypes.Role, userRepository.GetRole(userdata.Id)));

				ClaimsPrincipal principal = new ClaimsPrincipal(claims);
				HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

				return RedirectToAction("index" ,"Home");        //view if user is autho


			}
			return View(userdata);
		}
		public IActionResult Sign_In()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Sign_In(User user)
        {
            if (userRepository.Find(user.Name, user.Password))
            {

                User UserAccount = userRepository.GetUserByNameAndPassword(user.Name, user.Password);     // &&isAdmin==false

                if (UserAccount != null)
                {


                    //create cookie
                    ClaimsIdentity claims =
                        new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                    claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, UserAccount.Id.ToString()));
                    claims.AddClaim(new Claim(ClaimTypes.Name, UserAccount.Name));
                    claims.AddClaim(new Claim(ClaimTypes.Role, userRepository.GetRole(user.Id)));

                    ClaimsPrincipal principal = new ClaimsPrincipal(claims);
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("index", "Home");       //view if user is autho
                }
                else
                {
                    return RedirectToAction("~/Views/Admin/Dashboard.cshtml");   //isAdmin ==true
                }
            }

            return View(user);
        }



        
        public async Task<IActionResult> Logout()
        {

            // Sign out the user
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

			return RedirectToAction("index", "Home");      //view when user log out 
        }
    }
}
