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
          //  ModelState doğrulamasını bypass et, doğrudan kullanıcı verileriyle işlem yap
                      var context = DbContextHelper.CreateContext();
            User? usr = await context.Users.FirstOrDefaultAsync(u => u.EMail == user.EMail && u.Password == user.Password && u.Active == true);

            if (usr != null)
            {
                HttpContext.Session.SetString("NameSurname", usr.NameSurname);
                return RedirectToAction("Index", "Home", usr);

            }
            else
            {
                ViewBag.error = "Bilgiler Yanlış";
            }
     
            return View();
        }


    }
}
