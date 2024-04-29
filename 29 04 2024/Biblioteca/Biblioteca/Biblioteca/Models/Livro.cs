using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Models {
    public class Livro : Conteudo {
        private int _nrPaginas;
        //RN1: nrPaginas < 1 --> nrPaginas = 1
        public int NrPaginas { 
            get { return _nrPaginas;} 
            set { 
                _nrPaginas = value; 
                if (_nrPaginas < 1) _nrPaginas = 1;
            }
        }      

        public Livro() : base() {
            NrPaginas = 0;
        }

        public override string exportar() {
            string resultado = base.exportar();
            resultado += $"<nrpaginas>{NrPaginas}</nrpaginas>";
            return resultado;
        }
    }
}
