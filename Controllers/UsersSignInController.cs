﻿using Microsoft.AspNetCore.Authentication.Cookies;
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
        public IActionResult Sign_Up(User user)
        {
			SignUPUserViewModel userVM = new SignUPUserViewModel();
            userVM.Name = user.Name;
            userVM.Password = user.Password;
            User user3 = userRepository.GetByUserName(user.Name);
            if (user3 != null)
            {
                return Content("Username already taken");
            }
            else if (ModelState.IsValid)
            {

                userRepository.Insert(user);
                userRepository.Save();
                ClaimsIdentity claims = new ClaimsIdentity(
                    CookieAuthenticationDefaults.AuthenticationScheme);
                claims.AddClaim(new Claim("Id", user.Id.ToString()));
                claims.AddClaim(new Claim("Name", user.Name));

                claims.AddClaim(new Claim(ClaimTypes.Role, userRepository.GetRole(user.Id)));

                ClaimsPrincipal principal = new ClaimsPrincipal(claims);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return View();        //view if user is autho

            }
            return View(user);
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

                User UserAccount = userRepository.GetUserByNameAndPassword(user.Name, user.Password);
                // create cookie
                ClaimsIdentity claims =
                    new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier , UserAccount.Id.ToString()));
                claims.AddClaim(new Claim(ClaimTypes.Name, UserAccount.Name));
                claims.AddClaim(new Claim(ClaimTypes.Role, userRepository.GetRole(user.Id)));

                ClaimsPrincipal principal = new ClaimsPrincipal(claims);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return View();       //view if user is autho
            }

            return View(user);
        }



        [HttpPost]
        public async Task<IActionResult> Logout()
        {

            // Sign out the user
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction();       //view when user log out 
        }
    }
}