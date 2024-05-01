using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseuCE.Models
{
    public class Pintura : Exposicao
    {
        private string _classificacao;
        //RN1: classificacao < 1 OU > 5 OU vazio --» "Classificação Pendente"

        public string Classificacao
        {
            get { return _classificacao; }
            set
            {
                _classificacao = value.Trim();
                if (_classificacao != "1" || _classificacao != "2" || _classificacao != "3" || _classificacao != "4" || _classificacao != "5") _classificacao = "Classificação Pendente";
            }
        }

        public Pintura() : base()
        {
            Classificacao = "";
        }

        public override string exportar()
        {
            string export = base.exportar();
            export += $"<classificacao>{Classificacao}</classificacao>";
            return export;
        }
    }
}
