using CRUD.Data;
using CRUD.Models.Account;
using CRUD.Models.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CRUD.Controllers.Account
{
    public class AccountController : Controller
    {
        private readonly ApplicationContext context;

        public AccountController(ApplicationContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
         public IActionResult Login(LoginSignUpViewModel model)
        {
             if(ModelState.IsValid)
            {
                var data = context.users.Where(e => e.Email == model.Email).SingleOrDefault();
                if(data !=null)
                {
                    bool isValid = (data.Email == model.Email && data.Password == model.Password);
                    if(isValid)
                    {
                        var identity = new ClaimsIdentity(new[] { new Claim( ClaimTypes.Name, model.Email) }, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                        HttpContext.Session.SetString("Email",model.Email);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData["errorPassword"] = "Invalid Password ";
                        return View(model);
                    }
                }
                else
                {
                    TempData["errorEmail"] = "User not found!";
                    return View(model);
                }
            }
             else
            {
                return View(model);

            }
            
        }
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var storedCookies = Request.Cookies.Keys;
            foreach(var cookies in storedCookies)
            {
                Response.Cookies.Delete(cookies);
            }
            return RedirectToAction("Index", "Home");
        }
       
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(SignUpViewModel model )
        {
            if (ModelState.IsValid)
            {
                var data = new User()
                {
                    Username = model.Username,
                    Email = model.Email,
                    Password = model.Password,
                    Mobile = model.Mobile,
                    IsActive=model.IsActive
                };
                context.users.Add(data);
                context.SaveChanges();
                TempData["SuccessMessage"] = "You are eligible to login, please fill your own credential then login";
                return RedirectToAction("Login");
            }
            else
            {

                TempData["error message"] = "Empty form can not be submit.";
                return View(model);
            }
           
        }

    }
}
