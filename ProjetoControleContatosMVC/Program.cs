using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ProjetoControleContatosMVC.Data;
using ProjetoControleContatosMVC.Repositorio;

namespace ProjetoControleContatosMVC

{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<BancoContext>(options =>
            {
                options.UseSqlServer("Data source=DESKTOP-CR06JKF\\SQLSERVER;Initial Catalog=Aplicacao;User Id=sa;Password=adri;TrustServerCertificate=True;MultipleActiveResultSets=true");
            });
            builder.Services.AddScoped<IContatoRepositorio, ContatoRepositorio>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }


       // public IConfiguration Configuration { get; }




    }

}
