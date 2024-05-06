namespace ProdutoCore.Models
{
    public class Produto
    {
        private string _id;
        private string _nome;
        public string _stock;

        public string Nome
        {
            get { return _nome; }
            set
            {
                _nome = value.Trim();
                if (_nome.Length < 3) _nome = "Produto desconhecido";
            }
        }

        public string 
    }
}
