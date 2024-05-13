using Microsoft.AspNetCore.Mvc;
using DemoObjetos.Models;

namespace DemoObjetos.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IndexXPto(string id)
        {
            //return View();
            //return Content ($"Enviou valores: {id}");

            return new UpperMeResult("esTE tExto mALuço");

        }
    }
}
