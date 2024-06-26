namespace CoreSQL.Models {
    public class Medicamento
    {
        public string Utilizador { get; set; }
        public string Nome { get; set; }
        public int Frequencia { get; set; }
        public int Quantidade { get; set; }
        public DateTime UltimoConsumo { get; set; }
    }
}
