using Microsoft.Data.SqlClient;
using System.Data;

namespace CoreSQL.Models
{
    public class DocumentoHelper
    {
        private readonly string _conexao;

        public DocumentoHelper(string conexao)
        {
            _conexao = conexao;
        }

        public List<Documento> list(int tipoEstado)
        {
            DataTable docs = new DataTable();
            List<Documento> outList = new List<Documento>();
            SqlDataAdapter telefone = new SqlDataAdapter();
            SqlCommand comando = new SqlCommand();
            SqlConnection conexao = new SqlConnection(_conexao);

            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM tDocumento WHERE estado = @estado";
            comando.Parameters.AddWithValue("@estado", tipoEstado);

            comando.Connection = conexao;
            telefone.SelectCommand = comando;
            telefone.Fill(docs);

            conexao.Close();
            conexao.Dispose();

            foreach (DataRow linhadoc in docs.Rows)
            {
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
    }
}
