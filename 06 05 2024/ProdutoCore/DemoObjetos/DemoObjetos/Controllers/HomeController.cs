using Microsoft.AspNetCore.Mvc;

namespace DemoObjetos.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(int x, int y, int z)
        {
            //return View();
            return Content ($"Enviou valores: {x} | {y} | {z}");
        }
    }
}
