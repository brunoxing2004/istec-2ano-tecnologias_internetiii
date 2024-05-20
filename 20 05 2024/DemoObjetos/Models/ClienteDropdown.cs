namespace DemoObjetos.Models
{
    public class ClienteDropdown
    {
        public Guid Id { get; set; }
        public string Designacao { get; set; }
        public ClienteDropdown()
        {
            Id = Guid.NewGuid();
            Designacao = "";
        }
    }
}
