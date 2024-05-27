using CoreSQL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreSQL.Controllers
{
    public class DocumentoController : Controller
    {
        public IActionResult Listar()
        {
            string ligacao = Program.conexaoGlobal;
            DocumentoHelper dh = new DocumentoHelper(ligacao);
            List<Documento> lista = dh.list(1);
            return View(lista);
        }
    }
}
