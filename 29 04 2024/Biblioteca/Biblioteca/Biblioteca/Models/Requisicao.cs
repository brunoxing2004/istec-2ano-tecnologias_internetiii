using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Models {
    public class Requisicao {
        private List<Conteudo> _lstConteudo;
        private Leitor _requisitante;
        private DateTime _dataEmissao;

        public Leitor Requisitante
        {
            get { return _requisitante; }
            set { _requisitante = value; }
        }

        public DateTime DataEmissao
        {
            get { return _dataEmissao; }
        }

        public void Adicionar(Conteudo conteudo)
        {
            _lstConteudo.Add(conteudo);
        }

        public Requisicao()
        {
            _lstConteudo = new List<Conteudo>();
            _dataEmissao = DateTime.Now;
            Requisitante = new Leitor();

        }
    }
}
