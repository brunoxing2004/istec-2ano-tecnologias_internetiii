namespace DemoObjetos.Models
{
    public class Produto
    {
        private Guid _id;
        private string _nome;
        private decimal _pv;
        private decimal _stock;

        public Guid Id
        {
            get { return _id; }
        }

        public string Nome
        {
            get { return _nome; }
            set
            {
                _nome = value.Trim();
                if (_nome.Length < 3) { _nome = "Nome produto indefenido"; }
            }

        }

        public decimal Pv
        {
            get { return _pv; }
            set
            {
                _pv = value;
                if ( _pv < 0) { _pv = 0; }
            }
        }

        public decimal Stock
        {
            get { return _stock; }
            set
            {
                _stock = value;
                if (_stock < 0) { _stock = 0;}
            }
        }

        public Produto()
        {
            _id = Guid.NewGuid();
            Nome = "";
            Pv = 0;
            Stock = 0;
        }
    }
}
