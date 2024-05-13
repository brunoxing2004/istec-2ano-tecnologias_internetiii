using Microsoft.AspNetCore.Mvc;

namespace DemoObjetos.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(string id)
        {
            //return View();
            return Content ($"Enviou valores: {id}");
        }
    }
}
