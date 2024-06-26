namespace CoreSQL.Models
{
    public class ContaLogin
    {
        //public string Utilizador { get; set; }
        private string _utilizador = "";
        private string _password = "";

        public string Utilizador
        {
            get { return _utilizador; }
            set { _utilizador = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
    }
}
