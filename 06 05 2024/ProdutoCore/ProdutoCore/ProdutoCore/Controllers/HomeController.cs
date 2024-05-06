using Microsoft.AspNetCore.Mvc;

namespace ProdutoCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
