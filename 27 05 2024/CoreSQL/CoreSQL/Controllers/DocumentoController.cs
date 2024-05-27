using CoreSQL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace CoreSQL.Controllers
{
    public class DocumentoController : Controller
    {
        public IActionResult Listar(string op)
        {
            string ligacao = Program.conexaoGlobal;
            DocumentoHelper dh = new DocumentoHelper(ligacao);

            int estadoAVer = 0;
            switch (op)
            {
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
        [HttpPost]
        public IActionResult Criar(Documento documento)
        {
            string ligacao = Program.conexaoGlobal;
            DocumentoHelper dh = new DocumentoHelper(ligacao);
            dh.save (documento);
            return RedirectToAction("Listar", "Documento");
        }

        [HttpGet]
        public IActionResult Editar(string op)
        {
            string ligacao = Program.conexaoGlobal;
            DocumentoHelper dh = new DocumentoHelper(ligacao);
            Documento doc = dh.get(op);
            if (doc == null) return RedirectToAction("Listar", "Documento"); //se user tentar alterar registo já apagado noutra sessão, ele redireciona para o início
            return View(doc);
        }
    }
}
