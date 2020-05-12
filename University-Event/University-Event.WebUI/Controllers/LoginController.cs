using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University_Event.Domain;
using University_Event.Persistence;
using University_Event.WebUI.Form;

namespace University_Event.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private UEDbContext db;

        public LoginController(UEDbContext context)
        {
            db = context;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AuthenticationModel user)
        {
            if (ModelState.IsValid)
            {
                Student student = await db.Students.FirstOrDefaultAsync(u => u.ID == user.Login && u.Password == user.Password);
                if (student != null)
                {
                    await Authenticate(user.Login, "Student");

                    return RedirectToAction("Index", "Student");
                }
                Admin admin = await db.Admins.FirstOrDefaultAsync(u => u.Email == user.Login && u.Password == user.Password);
                if (admin != null)
                {
                    await Authenticate(user.Login, "Admin");

                    return RedirectToAction("Index", "Admin");
                }
                ModelState.AddModelError("", "Невірний логін чи пароль");
            }
            return View("Index");
        }
        private async Task Authenticate(string userName, string role)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, role)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}