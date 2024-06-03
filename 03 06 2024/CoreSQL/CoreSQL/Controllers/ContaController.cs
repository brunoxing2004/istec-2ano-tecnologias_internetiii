using Microsoft.AspNetCore.Mvc;

namespace CoreSQL.Controllers
{
    public class ContaController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
