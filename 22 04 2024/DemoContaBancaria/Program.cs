using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoContaBancaria.Models;

namespace DemoContaBancaria
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Conta c = new Conta();

            c.Nome = "Xico";
            c.Nif = "123456789";
            c.creditar(1000);
            c.debitar(999);

            Console.WriteLine($"Conta do {c.Nome} com NIF {c.Nif} tem saldo de {c.Saldo} euros");
            Console.ReadKey();
        }
    }
}
