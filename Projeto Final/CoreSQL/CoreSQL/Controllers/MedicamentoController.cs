using CoreSQL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CoreSQL.Controllers {
    public class MedicamentoController : Controller {

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
            string guidSessao = _conta.ToString();
        }


        public IActionResult Listar(string op)
        {
            ViewBag.NivelAcesso = "" + HttpContext.Session.GetString("nivelAcesso");
            //string ligacao = Program.conexaoGlobal;
            MedicamentoHelper dh = new MedicamentoHelper();
            string guidUtilizador = ViewBag.NivelAcesso;
            List<Medicamento> lista = dh.List(guidUtilizador);
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
            if (_conta.NivelAcesso != "")
            {
                DocumentoHelper dh = new DocumentoHelper();
                Documento? doc = dh.get(op);
                if (doc == null) return RedirectToAction("Listar", "Medicamento");
                return View(doc);
            }
            return RedirectToAction("Listar", "Medicamento");
        }

        [HttpPost]
        public IActionResult Editar(Documento documento)
        {
            if (_conta.NivelAcesso != "")
            {
                //string ligacao = Program.conexaoGlobal;
                DocumentoHelper dh = new DocumentoHelper();
                dh.save(documento);
            }
            return RedirectToAction("Listar", "Documento");
        }
    }
}
