using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Models;

namespace Biblioteca {
    internal class Program {
        static void Main(string[] args) {
            //List<Conteudo> lstConteudo = new List<Conteudo>();  
            Livro l1 = new Livro();
            l1.Autor = "Almeida";
            l1.Titulo = "Viagens";
            l1.NrPaginas = 500;

            CD cd1 = new CD { Titulo = "Star Wars", Autor="John Williams", NrFaixas=30 };

            //lstConteudo.Add(l1);
            //lstConteudo.Add(cd1);
            //lstConteudo.Add(new Livro { Autor="Zeca", Titulo="25 Abril", NrPaginas=200});

            //foreach (Conteudo c in lstConteudo) {
            //    Console.WriteLine(c.exportar());
            //}

            Requisicao r1 = new Requisicao();
            r1.Adicionar(cd1);
            r1.Adicionar(l1);
            r1.Adicionar(new Livro { Autor = "Maria", Titulo = "IAGPT", NrPaginas = 1000 });
            r1.Requisitante = new Leitor { Nome = "Ximenes Leitor", NrLeitor = "12345" };

            Requisicao r2 = new Requisicao();
            r1.Adicionar(cd1);
            r1.Adicionar(l1);
            r1.Adicionar(new Livro { Autor = "Alex", Titulo = "IA2.0", NrPaginas = 199 });
            r1.Requisitante = new Leitor { Nome = "Alexandre", NrLeitor = "54321" };

            BM bm1 = new BM();
            bm1.Nome = "E=MC2";
            bm1.Adicionar(r1);
            bm1.Adicionar(r2);
            Console.WriteLine(bm1.exportar());

            //Console.WriteLine(r1.exportar());



            Console.ReadKey();
        
        }

    }
}
