using CoreSQL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreSQL.Controllers {
    public class DocumentoController : Controller {
        public IActionResult Listar(string op) {
            ViewBag.NivelAcesso = "" + HttpContext.Session.GetString("nivelAcesso");
            //string ligacao = Program.conexaoGlobal;
            DocumentoHelper dh = new DocumentoHelper();
            int estadoAVer = 0;
            switch(op) {
                case "":
                case "ativos":
                    estadoAVer = 1;
                    break;
                case "inativos":
                    estadoAVer = 0;
                    break;
                case "todos":
                    estadoAVer = 2;
                    break;
                default:
                    estadoAVer = 1;
                    break;
            }
            List<Documento> lista = dh.list(estadoAVer);
            return View(lista);
        }

        [HttpGet]
        public IActionResult Criar() {
            //string ligacao = Program.conexaoGlobal;
            //DocumentoHelper dh = new DocumentoHelper(ligacao);
            //Documento doc = new Documento { 
            //    DtPublicacao = DateTime.Now, 
            //    Estado = 1, 
            //    Resumo = "Criado automaticamente mas com guids distintos", 
            //    Titulo = "Criado Automatico" };
            //dh.save(doc);
            //return RedirectToAction("Listar", "Documento");
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Documento documento) {
            //string ligacao = Program.conexaoGlobal;
            DocumentoHelper dh = new DocumentoHelper();
            dh.save (documento);
            return RedirectToAction("Listar", "Documento");
        }

        [HttpGet]
        public IActionResult Editar(string op) {
            //string ligacao = Program.conexaoGlobal;
            DocumentoHelper dh = new DocumentoHelper();
            Documento? doc = dh.get(op);
            if (doc == null) return RedirectToAction("Listar", "Documento");
            return View(doc);
        }

        [HttpPost]
        public IActionResult Editar (Documento documento) {
            //string ligacao = Program.conexaoGlobal;
            DocumentoHelper dh = new DocumentoHelper();
            dh.save(documento);
            return RedirectToAction("Listar", "Documento");
        }

    }
}
