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
            get
        }
    }
}
