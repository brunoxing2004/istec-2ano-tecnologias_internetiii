using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Models {
    public class BM {
        private List<Requisicao> _lstRequisicao;
        private string _nome;

        //RN1: _nome < 3 --» _nome = "A definir"

        public string Nome
        {
            get { return _nome; }
            set
            {
                _nome = value.Trim();
                if (_nome.Length < 3) _nome = "A definir";
            }
        }

        public BM()
        {
            Nome = "";
            _lstRequisicao = new List<Requisicao>();
        }

        public void Adicionar(Requisicao requisicao)
        {
            _lstRequisicao.Add(requisicao);
        }

        public string exportar()
        {
            string resultado = $"<nome>{Nome}</nome>\n";
            resultado += "<requisicao>\n";
            foreach(Requisicao r in _lstRequisicao){
                resultado += $"{r.exportar()}\n";
            }
            resultado += "</requisicao>\n";
            return resultado;
        }
    }
}
