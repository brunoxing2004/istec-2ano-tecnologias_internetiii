using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseuCE.Models
{
    public class Bilhete
    {
        private List<Exposicao> _lstExposicao;
        private Visitante _visitante;
        private DateTime _dataBilhete;
        private int _preco;
        private int _precoPadrao;

        public Visitante Visita
        {
            get { return _visitante; }
            set { _visitante = value; }
        }

        public DateTime DataBilhete
        {
            get { return _dataBilhete; }
        }

        public void Add(Exposicao exposicao)
        {
            _lstExposicao.Add(exposicao);
        }

        public string Preco
        {
            get { return Convert.ToString(_preco); }
            set
            {
                _preco = Convert.ToInt32(value);
                if (_preco <= 0) _preco = _precoPadrao;
            }
        }

        public Bilhete()
        {
            _lstExposicao = new List<Exposicao>();
            _dataBilhete = DateTime.Now;
            Visita = new Visitante();
            Preco = "0";
            _precoPadrao = 0;
        }

        public string exportar()
        {
            string export = $"<databilhete>{DataBilhete}</databilhete>\n";
            export += $"<visitante>\n{Visita.exportar()}\n</visitante>";
            export += $"\n<exposicao>\n";
            foreach(Exposicao exp in _lstExposicao)
            {
                export += exp.exportar();
            }
            export += $"\n</exposicao>\n";
            export += $"<preco>{Preco}</preco>\n";
            return export;
        }
    }
}
