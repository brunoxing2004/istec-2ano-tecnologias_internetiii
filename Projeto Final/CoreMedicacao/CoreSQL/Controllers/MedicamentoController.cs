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

        private MedicamentoHelper _medicamentoHelper = new MedicamentoHelper();

        // GET: Medicamento/Editar/{id}
        public IActionResult Editar(string id)
        {
            var medicamento = _medicamentoHelper.Get(id);
            if (medicamento == null)
            {
                return NotFound();
            }
            return View(medicamento);
        }

        // POST: Medicamento/Editar/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Medicamento medicamento)
        {
            if (ModelState.IsValid)
            {
                _medicamentoHelper.Update(medicamento);
                return RedirectToAction(nameof(Listar));
            }
            return View(medicamento);
        }
    }
}
