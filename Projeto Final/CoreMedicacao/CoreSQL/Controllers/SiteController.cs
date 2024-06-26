using Microsoft.AspNetCore.Mvc;

namespace CoreSQL.Controllers
{
    public class SiteController : Controller
    {
        public IActionResult Contacto()
        {
            return View();
        }

        public IActionResult Acerca()
        {
            return View();
        }
    }
}
