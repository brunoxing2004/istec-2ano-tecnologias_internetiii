using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseuCE.Models
{
    public class Exposicao
    {
        private string _nome;
        private string _autor;


        //RN1: titulo se < 2 caracteres --» "Exposição do Museu"
        //RN2: auitor se < 2 caracteres --» "Autor desconhecido"

        public string Nome
        {
            get { return _nome; }
            set
            { 
                _nome = value.Trim();
                if (_nome.Length < 2 ) _nome = "Exposição do Museu";
            }
        }

        public string Autor
        {
            get { return _autor; }
            set
            { 
                _autor = value.Trim();
                if (_autor.Length < 2) _autor = "Autor desconhecido";
            }
        }

        public Exposicao()
        {
            Nome = "";
            Autor = "";
        }

        public virtual string exportar()
        {
            return $"<exposicao>{Nome}</exposicao><autor>{Autor}</autor>";
        }
    }
}
