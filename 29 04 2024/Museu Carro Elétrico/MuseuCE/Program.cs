using MuseuCE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseuCE
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Maquete maq1 = new Maquete();
            maq1.Nome = "Modelismo Ferroviário";
            maq1.Tipo = "Madeira";
            maq1.Autor = "José Pascoal";

            Pintura pint1 = new Pintura();
            pint1.Nome = "Pinturas do Porto e Explendor Elétrico";
            pint1.Classificacao = "5";
            pint1.Autor = "Maria das Rosas";

            Exposicao exp1 = new Exposicao();
            exp1.Nome = "O elétrico do Porto";
            exp1.Autor = "José Pascoal";


            Bilhete b1 = new Bilhete();
            b1.Preco = "10";
            b1.Add(maq1);
            b1.Add(pint1);
            b1.Add(exp1);
            b1.Visita = new Visitante { Nome = "Bruno", Id="1", Tipo = "1"};

            Museu mce1 = new Museu();
            mce1.Add(b1);
            Console.WriteLine(mce1.exportar());

            Console.ReadKey();


        }
    }
}
