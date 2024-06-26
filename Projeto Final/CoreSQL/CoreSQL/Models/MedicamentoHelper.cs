using CoreSQL.Controllers;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CoreSQL.Models {
    public class MedicamentoHelper : HelperBase {

        private string ConectorHerdado1 = "Data Source=DESKTOP-BRUNOPC\\SQLEXPRESS;Initial Catalog=MedicacaoRegisto;User ID=dbuser;Password=dbuser;TrustServerCertificate=true;";

        public List<Medicamento> list(string guid)
        {
            DataTable meds = new DataTable();
            List<Medicamento> outList = new List<Medicamento>();
            SqlDataAdapter telefone = new SqlDataAdapter();
            SqlCommand comando = new SqlCommand();

            // Initialize the connection string here
            string connectionString = ConectorHerdado1; // Replace with your actual connection string
            SqlConnection conexao = new SqlConnection(connectionString);

            try
            {
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SELECT * FROM tMedicacao WHERE (guid = @guid)";
                comando.Parameters.AddWithValue("@guid", guid);

                comando.Connection = conexao;
                telefone.SelectCommand = comando;

                // Open the connection before executing the command
                conexao.Open();
                telefone.Fill(meds);
            }
            catch (Exception ex)
            {
                // Handle any potential errors here
                throw new Exception("An error occurred while retrieving the data.", ex);
            }
            finally
            {
                // Ensure the connection is always closed
                conexao.Close();
                conexao.Dispose();
            }

            foreach (DataRow linhamed in meds.Rows)
            {
                Medicamento med = new Medicamento();
                med.Guid = linhamed["guid"].ToString();
                med.Nome = linhamed["nome"].ToString();
                med.Frequencia = Convert.ToByte(linhamed["frequencia"]);
                med.Quantidade = Convert.ToByte(linhamed["quantidade"]);
                med.UltimoConsumo = Convert.ToDateTime(linhamed["ultimoConsumo"]);
                outList.Add(med);
            }

            return outList;
        }





        public Documento? get(string uidDoc) {
            DataTable meds = new DataTable();
            Documento? outDoc = new Documento();
            SqlDataAdapter telefone = new SqlDataAdapter();
            SqlCommand comando = new SqlCommand();
            SqlConnection conexao = new SqlConnection(ConectorHerdado);

            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM tDocumento WHERE uid=@uid";
            comando.Parameters.AddWithValue("@uid", uidDoc);

            comando.Connection = conexao;
            telefone.SelectCommand = comando;
            telefone.Fill(meds);

            conexao.Close();
            conexao.Dispose();

            if (meds.Rows.Count == 1) {
                DataRow linhaDoc = meds.Rows[0];
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
