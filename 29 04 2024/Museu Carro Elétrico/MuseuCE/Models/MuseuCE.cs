using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseuCE.Models
{
    public class MuseuCE
    {
        private List<Bilhete> _lstBilhete;
        private string _nome;

        //RN1
        public string Nome
        {
            get { return _nome; }
        }

        public MuseuCE()
        {
            _nome = "Museu Carro Elétrico";
            _lstBilhete = new List<Bilhete>();
        }

        public void Add(Bilhete bilhete)
        {
            _lstBilhete.Add(bilhete);
        }

        public string exportar()
        {
            string export = $"<nomemuseu>{Nome}</nomemuseu>\n";
            export += $"<bilhete>\n";
            foreach(Bilhete bilhete in _lstBilhete)
            {
                export += $"{bilhete.exportar()}\n";
            }
            export += "</bilhete>";
            return export;
        }
    }
}
