using Microsoft.AspNetCore.Mvc;

namespace HeyatdanBezmek.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
