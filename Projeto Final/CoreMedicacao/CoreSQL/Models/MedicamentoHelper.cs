using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Mvc;
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

            string _connectionString = ConectorHerdado1;

            using (SqlConnection conexao = new SqlConnection(_connectionString))
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

            string _connectionString = ConectorHerdado1;

            using (SqlConnection conexao = new SqlConnection(_connectionString))
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

        public void save(Medicamento medicamento)
        {
            string _connectionString = ConectorHerdado1;
            using (SqlConnection conexao = new SqlConnection(_connectionString))
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexao;
                comando.CommandType = CommandType.Text;

                DateTime ultimoConsumo = medicamento.UltimoConsumo;

                if (string.IsNullOrEmpty(medicamento.GuidMedicamento))
                {
                    // Generate new GUID for the new Medicamento
                    //medicamento.GuidMedicamento = Guid.NewGuid().ToString();

                    comando.CommandText = "INSERT INTO tMedicacao (nome, frequencia, quantidade, ultimoConsumo) " +
                        "VALUES (@nome, @frequencia, @quantidade, @ultimoConsumo)";
                    //comando.Parameters.AddWithValue("@guidMedicamento", medicamento.GuidMedicamento);
                }
                else
                {
                    comando.CommandText = "UPDATE tMedicacao " +
                        "SET nome = @nome, " +
                        "frequencia = @frequencia, " +
                        "quantidade = @quantidade, " +
                        "ultimoConsumo = @ultimoConsumo " +
                        "WHERE guidMedicamento = @guidMedicamento";
                    comando.Parameters.AddWithValue("@guidMedicamento", medicamento.GuidMedicamento);
                }

                // Add parameters common to both INSERT and UPDATE operations
                comando.Parameters.AddWithValue("@nome", medicamento.Nome);
                comando.Parameters.AddWithValue("@frequencia", Convert.ToInt32(medicamento.Frequencia));
                comando.Parameters.AddWithValue("@quantidade", Convert.ToInt32(medicamento.Quantidade));
                comando.Parameters.AddWithValue("@ultimoConsumo", ultimoConsumo);

                conexao.Open();
                comando.ExecuteNonQuery();
                conexao.Close();
            }
        }


    }
}
