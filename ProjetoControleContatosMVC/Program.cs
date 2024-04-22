using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ProjetoControleContatosMVC.Data;
using ProjetoControleContatosMVC.Helper;
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

            //builder.Services.AddSingleton<IHttpContextAccessor>();
            builder.Services.AddScoped<IContatoRepositorio, ContatoRepositorio>();
            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            builder.Services.AddScoped<ISessao, Sessao>();

            //builder.Services.AddSession(o =>
            //{
            //    o.Cookie.HttpOnly = true;
            //    o.Cookie.IsEssential = true;
            //});


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Index}/{id?}");

            app.Run();
        }


       // public IConfiguration Configuration { get; }




    }

}
