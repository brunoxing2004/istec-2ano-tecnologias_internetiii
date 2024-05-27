internal class Program
{
    //public static string conexaoGlobal = "ITSDAAS-41407\\SQLEXPRESS; database=GestaoDocumental; uid=IUser; pwd=IUser; TrustServerCertificate=True; Encrypt=False";
    public static string conexaoGlobal = "Server=ITSDAAS-41407\\SQLEXPRESS; Database=GestaoDocumental; User Id=IUser; Password=IUser; TrustServerCertificate=True; Encrypt=False;";

    private static void Main(string[] args)
    {
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