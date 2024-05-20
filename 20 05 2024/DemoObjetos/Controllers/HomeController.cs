using Microsoft.AspNetCore.Mvc;
using DemoObjetos.Models;

namespace DemoObjetos.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult index()
        {

            return View();

        }

        public IActionResult GetDoc()
        {
            Documento documento = new Documento()
            {
                Titulo = "Fatura da Eletrecidade",
                Resumo = "Tenho de Comprar Lampadas class A",
                Estado = true,
            };
            ViewData["Origem"] = "Contabilidade";
            ViewBag.Destino = "Produção";
            return View(documento);
        }

        public IActionResult GetProduto()
        {
            Produto produto = new Produto()
            {
                Nome = "Massa",
                Pv = 5,
                Stock = 100,
            };
            return View(produto);
        }

        //public IActionResult IndexXPTO(string id)
        //{

        //    //return Content ($"O seu valor é: {id}!");
        //    return new UpperMeResult("ESte TExto Malucã");

        //}
    }
}