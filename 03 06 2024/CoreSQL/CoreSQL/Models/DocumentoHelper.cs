using Microsoft.Data.SqlClient;
using System.Data;

namespace CoreSQL.Models {
    public class DocumentoHelper {
        private readonly string _conexao;

        public DocumentoHelper(string conexao) {
            _conexao = conexao;
        }

        public List<Documento> list(int tipoEstado) {
            DataTable docs = new DataTable();
            List<Documento> outList = new List<Documento>();
            SqlDataAdapter telefone = new SqlDataAdapter();
            SqlCommand comando = new SqlCommand();
            SqlConnection conexao = new SqlConnection(_conexao);

            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM tDocumento WHERE (estado = @estado OR @estado = 2)";
            comando.Parameters.AddWithValue("@estado", tipoEstado);

            comando.Connection = conexao;
            telefone.SelectCommand = comando;
            telefone.Fill(docs);

            conexao.Close();
            conexao.Dispose();

            foreach (DataRow linhadoc in docs.Rows) {
                Documento doc = new Documento();
                doc.Uid = "" + linhadoc["uid"];
                doc.Titulo = "" + linhadoc["titulo"];
                doc.Resumo = "" + linhadoc["resumo"];
                doc.DtPublicacao = Convert.ToDateTime(linhadoc["dtPublicacao"]);
                doc.DtCriacao = Convert.ToDateTime(linhadoc["dtCriacao"]);
                doc.Estado = Convert.ToByte(linhadoc["estado"]);
                outList.Add(doc);
            }
            return outList;
        }

        public void save(Documento doc) {
            if (string.IsNullOrEmpty(doc.Uid)) {
                SqlCommand comando = new SqlCommand();
                SqlConnection conexao = new SqlConnection(_conexao);
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
            else {
                SqlCommand comando = new SqlCommand();
                SqlConnection conexao = new SqlConnection(_conexao);
                comando.Connection = conexao;
                comando.CommandType = CommandType.Text;
                comando.CommandText = " UPDATE tDocumento " +
                                        " SET titulo = @titulo, " +
                                        " resumo = @resumo, " + 
                                        " dtPublicacao = @dtPublicacao, " +
                                        " estado = @estado " +
                                        " WHERE uid = @uid ";
                comando.Parameters.AddWithValue("@titulo", doc.Titulo);
                comando.Parameters.AddWithValue("@resumo", doc.Resumo); 
                comando.Parameters.AddWithValue("@dtPublicacao", doc.DtPublicacao);

                comando.Parameters.AddWithValue("@estado", doc.Estado);
                comando.Parameters.AddWithValue("@uid", doc.Uid);
                conexao.Open();
                comando.ExecuteNonQuery();
                conexao.Close();
                conexao.Dispose();
            }
        }

        public Documento? get(string uidDoc) {
            DataTable docs = new DataTable();
            Documento? outDoc = new Documento();
            SqlDataAdapter telefone = new SqlDataAdapter();
            SqlCommand comando = new SqlCommand();
            SqlConnection conexao = new SqlConnection(_conexao);

            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM tDocumento WHERE uid=@uid";
            comando.Parameters.AddWithValue("@uid", uidDoc);

            comando.Connection = conexao;
            telefone.SelectCommand = comando;
            telefone.Fill(docs);

            conexao.Close();
            conexao.Dispose();

            if (docs.Rows.Count == 1) {
                DataRow linhaDoc = docs.Rows[0];
                outDoc.Uid = "" + linhaDoc["uid"];
                outDoc.Titulo = "" + linhaDoc["titulo"];
                outDoc.Resumo = "" + linhaDoc["resumo"];
                outDoc.DtPublicacao = Convert.ToDateTime(linhaDoc["dtPublicacao"]);
                outDoc.DtCriacao = Convert.ToDateTime(linhaDoc["dtCriacao"]);
                outDoc.Estado = Convert.ToByte(linhaDoc["estado"]);
                return outDoc;
            }
            else {
                outDoc = null;
            }
            return outDoc;
        }
    }
}
