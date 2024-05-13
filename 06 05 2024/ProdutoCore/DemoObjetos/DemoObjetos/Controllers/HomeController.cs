using Microsoft.AspNetCore.Mvc;

namespace DemoObjetos.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(int id)
        {
            //return View();
            return Content ($"Enviou valores: {id}");
        }
    }
}
