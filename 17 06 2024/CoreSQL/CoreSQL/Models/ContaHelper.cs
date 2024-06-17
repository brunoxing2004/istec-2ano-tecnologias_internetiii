using System.Text.Json;

namespace CoreSQL.Models
{
    public class ContaHelper
    {
        public Conta setGuest()
        {
            return new Conta
            {
                Uid = Guid.NewGuid().ToString(),
                Nome = "Anónimo",
                Email = "",
                NivelAcesso = 0

            };
        }

        public Conta authUser(string login, string password)
        {
            if (login == "admin@net.pt" && password == "1234")
            {
                return new Conta
                {
                    Uid = Guid.NewGuid().ToString(), //ID do utilizador
                    Nome = "Admin",
                    Email = "admin@istec.pt",
                    NivelAcesso = 2
                };
            }

            if (login == "operador@net.pt" && password == "4321")
            {
                return new Conta
                {
                    Uid = Guid.NewGuid().ToString(), //ID do utilizador
                    Nome = "Operador",
                    Email = "Operador@istec.pt",
                    NivelAcesso = 1
                };
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
