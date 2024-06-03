using Microsoft.AspNetCore.Mvc;

namespace CoreSQL.Controllers
{
    public class ContaController : Controller
    {
        public IActionResult Login()
        {
            HttpContext.Session.SetString("nivelAcesso", "1");
            return RedirectToAction("Listar", "Documento");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.SetString("nivelAcesso", "0");
            return RedirectToAction("Listar", "Documento");
        }
    }
}
