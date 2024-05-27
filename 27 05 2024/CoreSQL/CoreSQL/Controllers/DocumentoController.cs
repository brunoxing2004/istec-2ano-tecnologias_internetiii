using Microsoft.AspNetCore.Mvc;

namespace CoreSQL.Controllers
{
    public class DocumentoController : Controller
    {
        public IActionResult Listar()
        {
            string ligacao = Program.conexaoGlobal;
            return View();
        }
    }
}
