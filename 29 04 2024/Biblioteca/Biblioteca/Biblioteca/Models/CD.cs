﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Models {
    public class CD : Conteudo {
        private int _nrFaixas;

        //RN1: se nrFaixas < 1 --> nrFaixas = 1
        public int NrFaixas {
            get { return _nrFaixas; }
            set { 
                _nrFaixas = value;
                if (_nrFaixas < 1) _nrFaixas = 1;
            }
        }

        public CD () : base() {
            NrFaixas = 0;
        }

        //Graças ao Francisco-->overloading

        //public string xpto () {
        //    return "";
        //}

        //public void xpto(int x) {

        //}

        //public void xpto(int k, string x) {

        //}
        //public void xpto(string k, int x) {

        //}
        public override string exportar() {
            string resultado = base.exportar();
            resultado += $"<nrfaixas>{NrFaixas}</nrfaixas>";
            return resultado;
        }
    }
}
