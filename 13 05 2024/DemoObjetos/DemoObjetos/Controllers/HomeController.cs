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
            Documento doc = new Documento()
            {
                Titulo = "Fatura da Eletrecidade",
                Resumo = "Tenho de Comprar Lampadas class A",
                Estado = true,
            };
            return View(doc);
        }

        //public IActionResult IndexXPTO(string id)
        //{

        //    //return Content ($"O seu valor é: {id}!");
        //    return new UpperMeResult("ESte TExto Malucã");

        //}
    }
}