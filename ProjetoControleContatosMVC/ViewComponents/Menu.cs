using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoControleContatosMVC.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjetoControleContatosMVC.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            {
                string sessaoUsuario = HttpContext.Session.GetString("sessaoUsuarioLogado");

                if (string.IsNullOrEmpty(sessaoUsuario)) return null;

                UsuarioModel usuario = JsonSerializer.Deserialize<UsuarioModel>(sessaoUsuario);

                return View(usuario); 
            }
        }
    }
}
