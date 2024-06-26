using CoreMedicacao.Models;
using CoreSQL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CoreSQL.Controllers
{
    public class ContaController : Controller
    {

        private Conta? _conta;
        public override void OnActionExecuting(ActionExecutingContext aec)
        {
            base.OnActionExecuting(aec);

            ContaHelper cc = new ContaHelper();
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(Program.SessionContainerName)))
            {
                HttpContext.Session.SetString(Program.SessionContainerName, cc.serializeConta(cc.setGuest()));
            }
            _conta = cc.deSerializeConta("" + HttpContext.Session.GetString(Program.SessionContainerName));
            if (_conta != null) ViewBag.ContaAtiva = _conta;
            else ViewBag.ContaAtiva = cc.setGuest();
        }

        //public IActionResult Login()
        //{
        //    ContaHelper ch = new ContaHelper();
        //    //cOut é um admin nestas condições
        //    Conta cOut = ch.authUser("admin@net.pt", "1234");
        //    string contaSerializada = ch.serializeConta(cOut);
        //    HttpContext.Session.SetString(Program.SessionContainerName, contaSerializada);
        //    return RedirectToAction("Listar", "Documento");
        //}

        public IActionResult Logout()
        {
            ContaHelper ch = new ContaHelper();
            HttpContext.Session.Clear();
            string contaSerializada = ch.serializeConta(ch.setGuest());
            HttpContext.Session.SetString(Program.SessionContainerName, contaSerializada);
            return RedirectToAction("Login", "Conta");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(ContaLogin contaLogin)
        {
            if (!string.IsNullOrEmpty(contaLogin.Utilizador) && !string.IsNullOrEmpty(contaLogin.Password))
            {
                ContaHelper ch = new ContaHelper();
                Conta cOut = ch.autenticarUser(contaLogin.Utilizador, contaLogin.Password);

                if (cOut != null && cOut.NivelAcesso != "") // Verifica se a conta é válida
                {
                    string contaSerializada = ch.serializeConta(cOut);
                    HttpContext.Session.SetString(Program.SessionContainerName, contaSerializada);
                    return RedirectToAction("Listar", "Medicamento");
                }
            }

            // Se falhar, retornar para a página de login com uma mensagem de erro (opcional)
            ModelState.AddModelError("", "Utilizador ou password inválidos.");
            return View();
        }

        [HttpGet]
        public IActionResult Registar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registar(ContaRegisto contaRegisto)
        {
            if (contaRegisto.Utilizador != "" && contaRegisto.Password != "")
            {
                ContaHelper ch = new ContaHelper();
                //cOut é um admin nestas condições
                Conta cOut = ch.registarUser(contaRegisto.Utilizador, contaRegisto.Password);
                string contaSerializada = ch.serializeConta(cOut);
                HttpContext.Session.SetString(Program.SessionContainerName, contaSerializada);
            }

            return RedirectToAction("Login", "Conta");
        }

    }
}
