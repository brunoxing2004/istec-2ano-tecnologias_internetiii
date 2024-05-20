using Microsoft.AspNetCore.Mvc;
using DemoObjetos.Models;

namespace DemoObjetos.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetCliente()
        {
            Cliente cliente = new Cliente()
            {
                Nome = "Maria",
                Nif = "123456789",
            };

            List<ClienteDropdown> clienteOrientacao = new List<ClienteDropdown>();
            clienteOrientacao.Add(new ClienteDropdown { Designacao = "Masculino" });
            clienteOrientacao.Add(new ClienteDropdown { Designacao = "Feminino" });
            clienteOrientacao.Add(new ClienteDropdown { Designacao = "Não Binário" });
            ViewBag.MP = clienteOrientacao;
            return View(clienteOrientacao);
        }




    }
}
