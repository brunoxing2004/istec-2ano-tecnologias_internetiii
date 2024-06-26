using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.Data;
using System.Text.Json;

namespace CoreSQL.Models
{
    public class ContaHelper : HelperBase
    {
        public Conta setGuest()
        {
            return new Conta
            {
                Guid = Guid.NewGuid().ToString(),
                NivelAcesso = ""
            };
        }

        public Conta autenticarUser(string login, string password)
        {
            string connectionString = "Data Source=DESKTOP-BRUNOPC\\SQLEXPRESS;Initial Catalog=MedicacaoRegisto;User ID=dbuser;Password=dbuser;TrustServerCertificate=true;";
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                string query = "SELECT utilizador, password, guid FROM tUtilizadores WHERE utilizador = @login";
                using (SqlCommand comando = new SqlCommand(query, conexao))
                {
                    comando.Parameters.AddWithValue("@login", login);
                    try
                    {
                        conexao.Open();
                        using (SqlDataReader comandoDataReader = comando.ExecuteReader())
                        {
                            if (comandoDataReader.Read())
                            {
                                string loginValidado = comandoDataReader["utilizador"].ToString();
                                string passwordValidado = comandoDataReader["password"].ToString();
                                string guidValidado = comandoDataReader["guid"].ToString();
                                if (login == loginValidado && password == passwordValidado)
                                {
                                    return new Conta
                                    {
                                        Guid = guidValidado,
                                        NivelAcesso = guidValidado,
                                        Utilizador = login
                                    };
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log or handle the exception as needed
                        throw new ApplicationException("Erro ao autenticar o usuário", ex);
                    }
                }
            }

            return setGuest();
        }





        public Conta registarUser(string login, string password)
        {
            string connectionString = "Data Source=DESKTOP-BRUNOPC\\SQLEXPRESS;Initial Catalog=MedicacaoRegisto;User ID=dbuser;Password=dbuser;TrustServerCertificate=true;";
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO tUtilizadores (utilizador, password) VALUES (@login, @password)";
                using (SqlCommand comando = new SqlCommand(query, conexao))
                {
                    comando.Parameters.AddWithValue("@login", login);
                    comando.Parameters.AddWithValue("@password", password);

                    try
                    {
                        conexao.Open();
                        int rowsAffected = comando.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            return new Conta
                            {
                                Guid = Guid.NewGuid().ToString(),
                                NivelAcesso = ""
                            };
                        }
                        else
                        {
                            throw new ApplicationException("Erro ao registrar o usuário. Nenhuma linha foi afetada.");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log or handle the exception as needed
                        throw new ApplicationException("Erro ao registrar o usuário", ex);
                    }
                    finally
                    {
                        conexao.Close();
                    }
                }
            }

            return setGuest();
        }


        public string serializeConta(Conta conta)
        {
            return JsonSerializer.Serialize<Conta>(conta);
        }
        public Conta deSerializeConta(string contaSerializada)
        {
            Conta? conta;
            try
            {
                conta = JsonSerializer.Deserialize<Conta>(contaSerializada);
            }
            catch
            {
                conta = null;
            }
            return conta;
        }

    }
}
