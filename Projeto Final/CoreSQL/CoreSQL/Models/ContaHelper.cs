using Microsoft.Data.SqlClient;
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
                NivelAcesso = 0
            };
        }

        public Conta authUser(string login, string password)
        {

            SqlCommand comando = new SqlCommand();
            SqlConnection conexao = new SqlConnection(ConectorHerdado);
            comando.Connection = conexao;
            comando.CommandType = CommandType.Text;
            string loginValidado = comando.CommandText = "SELECT utilizador FROM tUtilizadores WHERE utilizador = @login";
            comando.Parameters.Add(new SqlParameter("@login", login));
            conexao.Open();
            comando.ExecuteNonQuery();
            conexao.Close();
            conexao.Dispose();

            if (login != loginValidado && password == "1234")
            {
                return new Conta
                {
                    NivelAcesso = 1
                };
            }

            if (string.IsNullOrEmpty(doc.Uid))
            {
                SqlCommand comando = new SqlCommand();
                SqlConnection conexao = new SqlConnection(ConectorHerdado);
                comando.Connection = conexao;
                comando.CommandType = CommandType.Text;
                comando.CommandText = " INSERT INTO tDocumento (titulo, resumo, dtPublicacao, estado) " +
                                        " VALUES (@titulo, @resumo, @dtPublicacao, @estado)";
                comando.Parameters.AddWithValue("@titulo", doc.Titulo);
                comando.Parameters.AddWithValue("@resumo", doc.Resumo);
                comando.Parameters.AddWithValue("@dtPublicacao", doc.DtPublicacao);
                comando.Parameters.AddWithValue("@estado", doc.Estado);
                conexao.Open();
                comando.ExecuteNonQuery();
                conexao.Close();
                conexao.Dispose();
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
