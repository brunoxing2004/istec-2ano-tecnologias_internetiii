using Microsoft.AspNetCore.Mvc;

namespace CoreSQL.Controllers
{
    public class ContaController : Controller
    {
        public IActionResult Login()
        {
            HttpContext.Session.SetString("nivelAcesso", "1");
            return RedirectToAction("Documento", "Listar");
        }


    }
}
