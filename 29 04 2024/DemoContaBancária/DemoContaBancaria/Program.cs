using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoContaBancaria.Models;

namespace DemoContaBancaria {
    internal class Program {
        static void Main(string[] args) {
            Conta c = new Conta();

            //c.pressaoPneus = 0;

            //int x = c.pressaoPneus;

            //c._nome = "XPTO";
            c.Nome = "Maria";

            //c.setNome("Xico");  //   --- c.Nome = "Xico";
            //c.setNif("123456789");
            c.Nif = "123456789";
            //c.setSaldo(0);        PROIBIDO

            //c.Saldo = 100000000;  PROIBIDO readonly

            c.creditar(1000);
            c.debitar(999);

            //Console.WriteLine($"Conta do {c.getNome()} com nif {c.getNif()} tem saldo {c.getSaldo()} Euros");
            Console.WriteLine($"Conta do {c.Nome} com nif {c.Nif} tem saldo {c.Saldo} Euros");
            Console.ReadKey();



        }
    }
}
