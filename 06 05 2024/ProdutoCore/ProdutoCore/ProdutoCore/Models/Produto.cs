namespace ProdutoCore.Models
{
    public class Produto
    {
        private Guid _id;
        private string _nome;
        private decimal _stock;

        public string Nome
        {
            get { return _nome; }
            set
            {
                _nome = value.Trim();
                if (_nome.Length < 3) _nome = "Produto desconhecido";
            }
        }

        public decimal Stock
        {
            get { return _stock; }
            set
            {
                _stock = value;
                if (_stock < 0) _stock = 0;
            }
        }

        public Guid Id
        {
            get { return _id; }
        }

        public Produto()
        {
            _id = Guid.NewGuid();
            Nome = "";
            Stock = 0;
        }
    }
}
