using Microsoft.AspNetCore.Mvc;
using ProjetoControleContatosMVC.Filters;

namespace ProjetoControleContatosMVC.Controllers
{
    [PaginaParaUsuarioLogado]
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
