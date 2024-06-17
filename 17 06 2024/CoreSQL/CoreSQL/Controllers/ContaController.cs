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
            return RedirectToAction("Listar", "Documento");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(ContaLogin contaLogin)
        {
            if (contaLogin.Email != "" && contaLogin.Senha != "")
            {
                ContaHelper ch = new ContaHelper();
                //cOut é um admin nestas condições
                Conta cOut = ch.authUser(contaLogin.Email, contaLogin.Senha);
                string contaSerializada = ch.serializeConta(cOut);
                HttpContext.Session.SetString(Program.SessionContainerName, contaSerializada);
            }
            return RedirectToAction("Listar", "Documento");
        }
    }
}
