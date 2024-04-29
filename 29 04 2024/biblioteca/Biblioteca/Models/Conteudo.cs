using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    public class Conteudo
    {
        private string _titulo;
        private string _autor;

        //RN1: titulo se < 3 caracteres --» "A definir"
        public string Titulo{
            get { return _titulo; }
            set {
                _titulo = value.Trim();
                if (_titulo.Length < 3) _titulo = "A definir";
            }
        }

        public string Autor
        {
            get { return _autor; }
            set { _autor = value.Trim(); }
        }

        public Conteudo()
        {
            Titulo = "";
            Autor = "";
        }

        public virtual string exportar()
        {
            return $"<titulo>{Titulo}</titulo><autor>{Autor}</titulo>";
        }
    }
}
