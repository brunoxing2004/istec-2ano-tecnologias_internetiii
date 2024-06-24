using System.Text.Json;

namespace CoreSQL.Models
{
    public class ContaHelper
    {
        public Conta setGuest()
        {
            return new Conta
            {
                Guid = Guid.NewGuid().ToString(),
                NivelAcesso = 0
            };
        }

        public Conta authUser(string login, string password)
        {
            if (login == "admin@net.pt" && password == "1234")
            {
                return new Conta
                {
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
