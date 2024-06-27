using CoreSQL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Razor.TagHelpers;

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
            ViewBag.NivelAcesso = HttpContext.Session.GetString("nivelAcesso");
            string userSessao = HttpContext.Session.GetString("Utilizador");
            

            MedicamentoHelper mh = new MedicamentoHelper();
            List<Medicamento> lista = mh.List(userSessao);

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

        

        [HttpGet]
        public IActionResult Editar(string op)
        {
            if (_conta.NivelAcesso != null || _conta.NivelAcesso != "")
            {
                MedicamentoHelper mh = new MedicamentoHelper();
                Medicamento? med = mh.Get(op);
                if (med == null) RedirectToAction("Listar", "Medicamento");
                return View(med);
            }
            return RedirectToAction("Login", "Conta");

        }

        [HttpPost]
        public IActionResult Editar(Medicamento medicamento)
        {
            try
            {
                MedicamentoHelper mh = new MedicamentoHelper();
                mh.save(medicamento);
                return RedirectToAction("Listar", "Medicamento"); // Redirect to the list view after saving
            }
            catch (Exception ex)
            {
                // Log exception
                return StatusCode(500, "Internal server error");
            }
        }

        
    }
}
