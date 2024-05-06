using Microsoft.AspNetCore.Mvc;

namespace DemoCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
