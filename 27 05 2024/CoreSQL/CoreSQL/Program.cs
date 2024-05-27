internal class Program
{
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