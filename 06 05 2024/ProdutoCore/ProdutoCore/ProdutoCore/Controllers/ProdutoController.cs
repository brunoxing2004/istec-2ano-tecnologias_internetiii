using Microsoft.AspNetCore.Mvc;
using ProdutoCore.Models;
using System.Collections.Generic;
using System.Text.Json;
using System.Xml.Serialization;

namespace ProdutoCore.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public string GetJson()
        {
            List<Produto> produtos = new List<Produto>
            {
                new Produto { Nome = "Pera", Stock = 3 },
                new Produto { Nome = "Maçã", Stock = 10 }
            };
            string jsonOut = JsonSerializer.Serialize(produtos);
            return jsonOut;
        }
        public IActionResult GetXML()
        {
            List<Produto> produtos = new List<Produto>
            {
                new Produto { Nome = "Pera", Stock = 3 },
                new Produto { Nome = "Maçã", Stock = 10 }
            };
            XmlSerializer x = new XmlSerializer(produtos.GetType());
            StringWriter sw = new StringWriter();
            x.Serialize(sw, produtos);
            return Content(sw.ToString());
        }
    }
}
