namespace CoreSQL.Models
{
    public class Conta
    {
        public string Guid { get; }
        public string Utilizador { get; set; }
        public string Password { get; set; }
        public int NivelAcesso { get; set; }

    }
}
