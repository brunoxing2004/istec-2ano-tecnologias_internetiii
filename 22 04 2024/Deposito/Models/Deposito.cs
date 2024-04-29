using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoContaBancaria.Models
{
    public class Deposito
    {
        #region "Atributos"
        private decimal _capacidadeMax;
        private decimal _capacidade;
        #endregion

        #region "Getters/Setters"

        public decimal capacidadeMax
        {
            get { return _capacidadeMax; }
        }

        public decimal capacidade
        {
            get { return _capacidade; }
            set { _capacidade = value; }
        }
        #endregion

        #region "Constructors"
        public Deposito(decimal capacidade)
        {
            
        }
        #endregion

        #region "Funcionalidades"
        public void injetar(decimal quantia)
        {
            if ( quantia <= capacidadeMax )
            {
                capacidade += quantia;
            }
        }

        public void retirar(decimal quantia)
        {
            if (quantia <= capacidadeMax)
            {
                capacidade  -= quantia;
            }
        }
        #endregion

    }
}
