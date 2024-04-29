using ProjetoControleContatosMVC.Models;

namespace ProjetoControleContatosMVC.Repositorio
{
    public interface IContatoRepositorio
    {
        ContatoModel ListarPorId(int usuarioId);

        List<ContatoModel> BuscarTodos(int id);
        ContatoModel Adicionar(ContatoModel contato);
        ContatoModel Atualizar(ContatoModel contato);

        bool Excluir(int id);
    }
}
