using System;

namespace CoreSQL.Models {
    public class Medicamento
    {

        string _guidMedicamento = "";
        string _utilizador = "";
        string _nome = "";
        int _frequencia = 0;
        int _quantidade = 0;
        DateTime _ultimoConsumo = DateTime.Now;

        //blic string GuidMedicamento { get; set; }
        //blic string Utilizador { get; set; }
        //blic string Nome { get; set; }
        //blic int Frequencia { get; set; }
        //blic int Quantidade { get; set; }
        //DateTime UltimoConsumo { get; set; }
        

        public string GuidMedicamento
        {
            get { return _guidMedicamento; }
            set { _guidMedicamento = value; }
        }
        public string Utilizador
        {
            get { return _utilizador; }
            set { _utilizador = value; }
        }
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        public int Frequencia
        {
            get { return _frequencia; }
            set { _frequencia = value; }
        }
        public int Quantidade
        {
            get { return _quantidade; }
            set { _quantidade = value; }
        }
        public DateTime UltimoConsumo
        {
            get { return _ultimoConsumo; }
            set { _ultimoConsumo = value; }
        }
    }
}
