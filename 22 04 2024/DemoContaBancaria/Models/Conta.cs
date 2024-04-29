using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoContaBancaria.Models
{
    public class Conta
    /*
     * Nome se < 3 caracteres -» "Anónimo"
     * Nif se tamanho <> 9 caracteres -» "---------"
     * Saldo >= 0
    */
    {
        #region "Atributos"
        private string _nome;
        private string _nif;
        private decimal _saldo;
        #endregion

        #region "Getters/Setters"
        //public void setNome(string nome)
        //{
        //    _nome = nome.Trim();
        //    if (_nome.Length < 3) { _nome = "Anónimo"; }
        //}

        //public string getNome() { return _nome; }

        public string Nome
        {
            get { return _nome; }
            set
            {
                _nome = value.Trim();
                if (_nome.Length < 3) { _nome = "Anónimo"; }
            }
        }

        //public void setNif(string nif)
        //{
        //    _nif = nif.Trim();
        //    if (_nif.Length != 9) { _nif = "---------"; }
        //}

        //public string getNif() { return _nif;}

        public string Nif
        {
            get { return _nif; }
            set
            {
                _nif = value.Trim();
                if (_nif.Length != 9) { _nif = "---------"; }
            }
        }

        //public decimal getSaldo() { return _saldo;}

        public decimal Saldo
        {
            get { return _saldo; }
        }
        #endregion

        #region "Constructors"
        public Conta()
        {
            Nome = "";
            Nif = "";
            _saldo = 0;
        }
        #endregion

        #region "Funcionalidades"
        public void debitar(decimal quantia)
        {
            if ( quantia < 0 )
            {
                if (_saldo >= quantia)
                {
                    _saldo -= quantia;
                }
            }
        }

        public void creditar(decimal quantia)
        {
            if (quantia > 0)
            {
                _saldo += quantia;
            }
        }
        #endregion

    }
}
