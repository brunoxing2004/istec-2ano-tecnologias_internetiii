using CoreSQL.Models;

internal class Program {

    //public static string conexaoGlobal = "server=EDP-JR-10H2\\SQL14; database=GestaoDocumental; uid=IUser; pwd=IUser; TrustServerCertificate=False; Encrypt=False";

    public static string Conector = "";
    public static string SmtpIP = "";
    public static string SessionContainerName = "";

    private static void Main(string[] args) {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddSession(s => s.IdleTimeout = TimeSpan.FromMinutes(20));
        builder.Services.AddMvc();
        var config = builder.Configuration.GetSection("Configuracao").Get<Configuracao>();
        Conector = config.Conexao;
        SmtpIP = config.SmtpIP;
        SessionContainerName = "contaAtiva";

        var app = builder.Build();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseSession();

        //app.MapGet("/", () => "Hello World!");
        app.MapControllerRoute(
           name: "default",
           pattern: "{controller=Documento}/{action=Listar}/{op?}"
       );
        app.Run();
    }
}