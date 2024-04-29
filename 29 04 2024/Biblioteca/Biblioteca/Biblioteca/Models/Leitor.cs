using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Models {
    public class Leitor {
        private string _nome;
        private string _nrLeitor;

        //RN1: _nome < 3 caracteres --» "Anónimo"
        //RN2: _nrLeitor <> 5 caracteres --» "-----"

        public string Nome
        {
            get { return _nome; }
            set
            {
                _nome = value.Trim();
                if (_nome.Length < 3) _nome = "Anónimo";
            }

        }

        public string NrLeitor
        {
            get { return _nrLeitor; }
            set
            {
                _nrLeitor = value.Trim();
                if (_nrLeitor.Length != 5) _nrLeitor = "-----";
            }
        }

        public Leitor()
        {
            Nome = "";
            NrLeitor = "";

        }

        public string exportar()
        {
            return $"<nome>{Nome}</nome><nrleitor>{NrLeitor}</nrleitor>";
        }
    }
}
