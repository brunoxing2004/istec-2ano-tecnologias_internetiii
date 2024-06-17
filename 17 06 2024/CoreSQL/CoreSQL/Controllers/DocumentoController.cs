using CoreSQL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CoreSQL.Controllers {
    public class DocumentoController : Controller {

        private Conta? _conta;
        public override void OnActionExecuting(ActionExecutingContext aec)
        {
            base.OnActionExecuting(aec);

            ContaHelper cc = new ContaHelper();
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(Program.SessionContainerName)))
            {
                HttpContext.Session.SetString(Program.SessionContainerName, cc.serializeConta(cc.setGuest()));
            }//só entra se for a primeira vez a aceder ao site
            _conta = cc.deSerializeConta("" + HttpContext.Session.GetString(Program.SessionContainerName));
            if (_conta != null) ViewBag.ContaAtiva = _conta;
            else ViewBag.ContaAtiva = cc.setGuest();
        }

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
            if (_conta.NivelAcesso > 0)
            {
                DocumentoHelper dh = new DocumentoHelper();
                Documento? doc = dh.get(op);
                if (doc == null) return RedirectToAction("Listar", "Documento");
                return View(doc);
            }
            return RedirectToAction("Listar", "Documento");
        }

        [HttpPost]
        public IActionResult Editar(Documento documento)
        {
            if (_conta.NivelAcesso > 0)
            {
                //string ligacao = Program.conexaoGlobal;
                DocumentoHelper dh = new DocumentoHelper();
                dh.save(documento);
            }
            return RedirectToAction("Listar", "Documento");
        }
    }
}
