using Correção_Depósito.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Correção_Depósito
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Deposito d = new Deposito(50);
            d.injetar(30);
            d.injetar(15);
            d.injetar(50);
            d.retirar(10);
            Console.WriteLine($"Depósito com capacidade: {d.Capacidade} está com {d.Boia} preenchido");
            Console.ReadKey();
        }
    }
}
