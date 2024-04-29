using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Models;

namespace Biblioteca.Models
{
    public class BM
    {
        static void Main(string[] args)
        {
            List<Conteudo> lstConteudo = new List<Conteudo>();
            Livro l1 = new Livro();
            l1.Autor = "Almeida";
            l1.Titulo = "Viagens";
            l1.NrPaginas = 500;

            CD cd1 = new CD { Titulo = "Star Wars", Autor = "John Williams", NrFaixas = 30 };
        }
    }
}
