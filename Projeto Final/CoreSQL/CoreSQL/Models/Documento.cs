namespace CoreSQL.Models {
    public class Documento {
        public string Uid { get; set; }
        public string Titulo { get; set; }
        public string Resumo { get; set; }
        public DateTime DtPublicacao { get; set; }  
        public DateTime DtCriacao { get; set; }
        public int Estado { get; set; }

    }
}
