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

        [HttpGet]
        public IActionResult Criar()
        {
            ////string ligacao = Program.conexaoGlobal;
            ////DocumentoHelper dh = new DocumentoHelper(ligacao);
            ////Documento doc = new Documento {
            ////    DtPublicacao = DateTime.Now,
            ////    Estado = 1,
            ////    Resumo = "Criado automaticamente com GUIDs distintos",
            ////    Titulo = "Criado automaticamente"
            ////};
            ////dh.save(doc);
            ////return RedirectToAction("Listar", "Documento"); //pode ir para outro controlador, mesmo sendo na mesma view
            return View();        
        }
    }
}
