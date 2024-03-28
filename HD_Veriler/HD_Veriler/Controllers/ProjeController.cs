using Microsoft.AspNetCore.Mvc;

namespace HD_Veriler.Controllers
{
    public class ProjeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
