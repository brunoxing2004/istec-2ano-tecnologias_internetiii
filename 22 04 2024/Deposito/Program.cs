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
            Deposito d = new Deposito(1000);

            //d.retirar(100);
            d.injetar(200);

            Console.WriteLine($"Capacidade final do deposito: {d.capacidade}");
            Console.ReadKey();
        }
    }
}
