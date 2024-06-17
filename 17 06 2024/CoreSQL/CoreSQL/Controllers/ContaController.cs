using CoreSQL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreSQL.Controllers
{
    public class ContaController : Controller
    {
        public IActionResult Login()
        {
            ContaHelper ch = new ContaHelper();
            //cOut é um admin 
            Conta cOut = ch.authUser("admin@net.pt", "1234");
            HttpContext.Session.SetString(Program.SessionContainerName, "1");
            return RedirectToAction("Listar", "Documento");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.SetString("nivelAcesso", "0");
            HttpContext.Session.Clear();
            return RedirectToAction("Listar", "Documento");
        }
    }
}
