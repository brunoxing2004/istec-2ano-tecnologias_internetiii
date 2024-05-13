namespace DemoObjetos.Models
{
    public class Documento
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Resumo { get; set; }
        public Boolean Estado { get; set; }

        public Documento()
        {
            
        }

    }
}
