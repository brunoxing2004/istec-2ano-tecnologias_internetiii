using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Correção_Depósito.Models
{
    public class Deposito
    {
        private decimal _capacidade;
        private decimal _boia;

        public decimal Capacidade
        {
            get { return _capacidade; }
        }

        public decimal Boia
        {
            get { return _boia; }
        }

        public Deposito(decimal capacidadeDeposito)
        {
            _capacidade = capacidadeDeposito;
            _boia = 0;
        }

        public void retirar(decimal quantidade)
        {
            if (quantidade > 0)
            {
                if (quantidade <= Boia)
                {
                    _boia -= quantidade;
                }
            }
        }

        public void injetar(decimal quantidade)
        {
            if (quantidade > 0)
            {
                if (quantidade + Boia <= Capacidade)
                {
                    _boia += quantidade;
                }
            }
        }

    }
}
