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

        //RN1: _nome < 2 caracteres --» "Visitante"
        //RN2: _id < 6 caracteres --» "******"

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

        public Visitante()
        {
            Nome = "";
            Id = "";
        }

        public string exportar()
        {
            return $"<nome>{Nome}</nome><idvisitante>{Id}</idvisitante>";
        }
    }
}
