using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseuCE.Models
{
    public class Visitante
    {
        private string _nome;
        private string _id;
        private int _tipo;

        //RN1: _nome < 2 caracteres --» "Visitante"
        //RN2: _id < 6 caracteres --» "******"
        //RN3: se tipo = 0, adulto, se = 1, estudante, se diferente 0 ou 1, coloca zero

        public string Nome
        {
            get { return _nome; }
            set
            {
                _nome = value.Trim();
                if (_nome.Length < 2) _nome = "Visitante";
            }
        }

        public string Id
        {
            get { return Convert.ToString(_id); }
            set
            {
                _id = value.Trim();
                if (_id.Length < 6) _id = "******";
            }
        }

        public string Tipo
        {
            get { return Convert.ToString(_tipo); }
            set
            {
                _tipo = Convert.ToInt32(value.Trim());
                if (_tipo != 1 || _tipo != 0) _tipo = 0;
            }
        }

        public Visitante()
        {
            Nome = "";
            Id = "";
            Tipo = "0";
        }

        public string exportar()
        {
            return $"<nomevisitante>{Nome}</nomevisitante>\n<idvisitante>{Id}</idvisitante>\n<tipo>{Tipo}</tipo>\n";
        }
    }
}
