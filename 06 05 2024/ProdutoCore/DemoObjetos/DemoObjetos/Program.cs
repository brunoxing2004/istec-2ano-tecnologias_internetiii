internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddMvc();  //Middleware
        var app = builder.Build();
        //app.MapGet("/", () => "Ol� Turma de TI-III!");
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}"
        );
        app.Run();
    }
}