using Microsoft.AspNetCore.Mvc;
using ProjetoControleContatosMVC.Filters;
using ProjetoControleContatosMVC.Models;
using ProjetoControleContatosMVC.Repositorio;

namespace ProjetoControleContatosMVC.Controllers
{
    [PaginaRestritaSomenteAdmin]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepositorio.BuscarTodos();
            return View(usuarios);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }
        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso! ";
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            catch (SystemException erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu usuário, tente novamente! Detalhes do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult ExcluirConfirmacao(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }

        public IActionResult Excluir(int id)
        {
            try
            {
                bool apagado = _usuarioRepositorio.Excluir(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Usuá´rio excluido com sucesso! ";
                }
                else
                {
                    TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu usuário, tente novamente!";
                }
                return RedirectToAction("Index");
            }
            catch (SystemException erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu usuário, tente novamente! Detalhes do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Editar(UsuarioSemSenhaModel usuarioSemSenhaModel)
        {
            try
            {
                UsuarioModel usuario = null;
                if (ModelState.IsValid)
                {
                    usuario = new UsuarioModel()
                    {
                        Id = usuarioSemSenhaModel.Id,
                        Nome = usuarioSemSenhaModel.Nome,
                        Login = usuarioSemSenhaModel.Login,
                        Email = usuarioSemSenhaModel.Email,
                        Perfil = usuarioSemSenhaModel.Perfil
                    };

                    usuario = _usuarioRepositorio.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Usuário alterado com sucesso! ";
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }

            catch (SystemException erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos atualizar seu usuário, tente novamente! Detalhes do erro:{erro.Message}";
                return RedirectToAction("Index");
            }

        }
    }
}
