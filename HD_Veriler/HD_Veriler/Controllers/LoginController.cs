using FluentValidation;
using HD_Veriler.Models;
using HD_Veriler.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading;
using HD_Veriler.Helpers;
using Microsoft.EntityFrameworkCore;
using HD_Veriler.Validators;
using Microsoft.CodeAnalysis;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace HD_Veriler.Controllers
{
    public class LoginController : Controller
    {
        private readonly IDependencyService _dependencyService;

        public LoginController(IDependencyService dependencyService)
        {
            _dependencyService = dependencyService;
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(User user)
        {
            var context = DbContextHelper.CreateContext();
            User? usr = await context.Users.FirstOrDefaultAsync(u => u.EMail == user.EMail && u.Password == user.Password && u.Active == true);

            if (usr != null)
            {
                var roles = await GetRolesForUserAsync(usr); // Kullanıcı rollerini al

                // Kullanıcı oturumunu açarken rol bilgilerini ekleyin
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usr.NameSurname),
                };

                // Kullanıcıya rolleri ekle
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties();
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                HttpContext.Session.SetString("NameSurname", usr.NameSurname);
                return RedirectToAction("Index", "Home", usr);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Bilgiler Yanlış");
                return View(user);
            }
        }

        // Kullanıcı için rolleri al
        private async Task<List<string>> GetRolesForUserAsync(User user)
        {
            var roles = new List<string>();

            // Kullanıcının rol bilgilerini al
            if (user.RolID == 1)
            {
                roles.Add("admin");
            }
            else if (user.RolID == 2)
            {
                roles.Add("editör");
            }

            return roles;
        }
    }
}
