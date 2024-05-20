namespace DemoObjetos.Models
{
    public class ItemDropdown
    {
        public Guid Id { get; set; }
        public string Designacao { get; set; }
        public ItemDropdown()
        {
            Id = Guid.NewGuid();
            Designacao = "";
        }
    }
}
