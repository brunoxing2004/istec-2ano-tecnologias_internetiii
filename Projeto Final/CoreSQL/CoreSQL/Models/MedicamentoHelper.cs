using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace CoreSQL.Models
{
    public class MedicamentoHelper : HelperBase
    {
        private readonly string ConectorHerdado1 = "Data Source=DESKTOP-BRUNOPC\\SQLEXPRESS;Initial Catalog=MedicacaoRegisto;User ID=dbuser;Password=dbuser;TrustServerCertificate=true;";

        public List<Medicamento> List(string utilizador)
        {
            DataTable meds = new DataTable();
            List<Medicamento> outList = new List<Medicamento>();

            string connectionString = ConectorHerdado1;

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand comando = new SqlCommand("SELECT * FROM tMedicacao WHERE utilizador = @utilizador", conexao))
                    {
                        comando.CommandType = CommandType.Text;
                        comando.Parameters.AddWithValue("@utilizador", utilizador);

                        using (SqlDataAdapter telefone = new SqlDataAdapter(comando))
                        {
                            conexao.Open();
                            telefone.Fill(meds);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao receber dados.", ex);
                }
            }

            foreach (DataRow linhamed in meds.Rows)
            {
                Medicamento med = new Medicamento
                {
                    Nome = linhamed["nome"].ToString(),
                    Frequencia = Convert.ToByte(linhamed["frequencia"]),
                    Quantidade = Convert.ToByte(linhamed["quantidade"]),
                    UltimoConsumo = Convert.ToDateTime(linhamed["ultimoConsumo"])
                };
                outList.Add(med);
            }

            return outList;
        }
    }
}
