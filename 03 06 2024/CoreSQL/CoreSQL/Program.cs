internal class Program {

    //public static string conexaoGlobal = "server=EDP-JR-10H2\\SQL14; database=GestaoDocumental; uid=IUser; pwd=IUser; TrustServerCertificate=False; Encrypt=False";

    public static string Conector = "";
    public static string SmtpIP = "";

    private static void Main(string[] args) {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddMvc();
        var app = builder.Build();

        //app.MapGet("/", () => "Hello World!");
        app.MapControllerRoute(
           name: "default",
           pattern: "{controller=Documento}/{action=Listar}/{op?}"
       );
        app.Run();
    }
}