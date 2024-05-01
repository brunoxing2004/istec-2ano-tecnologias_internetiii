using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseuCE.Models
{
    public class Maquete : Exposicao
    {
        private string _tipo;
        //RN1: tipo < 2 --» "Classificação de tipo pendente"
        public string Tipo
        {
            get { return _tipo; }
            set
            {
                _tipo = value.Trim();
                if ( _tipo.Length < 2 ) _tipo = "Classificação de tipo pendente";
            }
        }

        public Maquete() : base()
        {
            Tipo = "";
        }

        public override string exportar()
        {
            string export = base.exportar();
            export += $"<tipomaquete>{Tipo}</tipomaquete>";
            return export;
        }
    }
}
