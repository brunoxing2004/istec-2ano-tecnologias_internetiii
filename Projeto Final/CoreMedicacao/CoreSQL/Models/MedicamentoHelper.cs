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
                    using (SqlCommand comando = new SqlCommand("SELECT * FROM tMedicacao", conexao))
                    {
                        comando.CommandType = CommandType.Text;


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
                    GuidMedicamento = linhamed["guidMedicamento"].ToString(),
                    Nome = linhamed["nome"].ToString(),
                    Frequencia = Convert.ToByte(linhamed["frequencia"]),
                    Quantidade = Convert.ToByte(linhamed["quantidade"]),
                    UltimoConsumo = Convert.ToDateTime(linhamed["ultimoConsumo"])
                };
                outList.Add(med);
            }

            return outList;
        }

        public Medicamento? Get(string uidMed)
        {
            DataTable meds = new DataTable();
            Medicamento? med = null;

            string connectionString = ConectorHerdado1;

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand comando = new SqlCommand("SELECT * FROM tMedicacao WHERE guidMedicamento = @uidMed", conexao))
                    {
                        comando.CommandType = CommandType.Text;
                        comando.Parameters.AddWithValue("@uidMed", uidMed);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(comando))
                        {
                            conexao.Open();
                            adapter.Fill(meds);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao receber dados.", ex);
                }
            }

            if (meds.Rows.Count > 0)
            {
                DataRow linhamed = meds.Rows[0];
                med = new Medicamento
                {
                    GuidMedicamento = linhamed["guidMedicamento"].ToString(),
                    Nome = linhamed["nome"].ToString(),
                    Frequencia = Convert.ToByte(linhamed["frequencia"]),
                    Quantidade = Convert.ToByte(linhamed["quantidade"]),
                    UltimoConsumo = Convert.ToDateTime(linhamed["ultimoConsumo"])
                };
            }

            return med;
        }

        public void Update(Medicamento medicamento)
        {
            string connectionString = ConectorHerdado1;

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "UPDATE tMedicacao SET nome = @Nome, frequencia = @Frequencia, quantidade = @Quantidade, ultimoConsumo = @UltimoConsumo WHERE guidMedicamento = @GuidMedicamento";
                    using (SqlCommand comando = new SqlCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@GuidMedicamento", medicamento.GuidMedicamento);
                        comando.Parameters.AddWithValue("@Nome", medicamento.Nome);
                        comando.Parameters.AddWithValue("@Frequencia", medicamento.Frequencia);
                        comando.Parameters.AddWithValue("@Quantidade", medicamento.Quantidade);
                        comando.Parameters.AddWithValue("@UltimoConsumo", medicamento.UltimoConsumo);

                        conexao.Open();
                        comando.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao atualizar dados.", ex);
                }
            }
        }



    }


}
