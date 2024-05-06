using DemoCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;
using System.Xml.Serialization;

namespace DemoCore.Controllers
{
    public class HomeController : Controller
    {


        //public IActionResult Index()
        //{
        //    return View();
        //}


        public string Index()
        {
            return "Finalmente";
        }

        public string GetJson()
        {
            Pessoa p = new Pessoa { Id = "123", Nif = "123456789", Nome = "Maria Felisberta" };
            string jsonOut = JsonSerializer.Serialize(p);
            return jsonOut;
        }

        public IActionResult GetXML()
        {
            Pessoa p = new Pessoa { Id = "321", Nif = "987654321", Nome = "Maria" };
            XmlSerializer x = new XmlSerializer(p.GetType());
            StringWriter sw = new StringWriter();
            x.Serialize(sw, p);
            return Content(sw.ToString());
        }

    }
}