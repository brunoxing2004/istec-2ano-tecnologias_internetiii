namespace CoreSQL.Models
{
    public class Conta
    {
        string _guid = "";
        string _utilizador = "";
        string _password = "";
        string _nivelAcesso = "";

        //public string Guid { get; set; }
        //public string Utilizador { get; set; }
        //public string Password { get; set; }
        //public string NivelAcesso { get; set; }

        public string Guid
        {
            get { return _guid; }
            set { _guid = value; }
        }

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

        public string NivelAcesso
        {
            get { return _nivelAcesso; }
            set { _nivelAcesso = value; }
        }



    }
}
