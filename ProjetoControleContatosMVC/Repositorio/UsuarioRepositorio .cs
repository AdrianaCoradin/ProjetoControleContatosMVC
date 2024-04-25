using ProjetoControleContatosMVC.Data;
using ProjetoControleContatosMVC.Models;

namespace ProjetoControleContatosMVC.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;

        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        UsuarioModel IUsuarioRepositorio.BuscarPorLogin(string login)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper()) ;
        }

        public UsuarioModel BuscarPorEmailELogin(string email, string login)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper() && x.Login.ToUpper() == login.ToUpper());
        }

        public UsuarioModel ListarPorId(int id)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public List<UsuarioModel> BuscarTodos()
        {
            return _bancoContext.Usuarios.ToList();
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            usuario.SetSenhaHash();
            _bancoContext.Usuarios.Add(usuario);
            _bancoContext.SaveChanges();
            return usuario;
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDB = ListarPorId(usuario.Id);

            if (usuarioDB == null) throw new System.Exception("Houve um erro na atualização do usuário!");

            usuarioDB.Nome = usuario.Nome;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Login = usuario.Login;
            usuarioDB.Perfil = usuario.Perfil;
            usuarioDB.DataAtualizacao = DateTime.Now;

            _bancoContext.Usuarios.Update(usuarioDB);
            _bancoContext.SaveChanges();

            return usuarioDB;

        }

        public bool Excluir(int id)
        {
            UsuarioModel usuarioDB = ListarPorId(id);

            if (usuarioDB == null) throw new System.Exception("Houve um erro ao excluir o usuário!");

            _bancoContext.Usuarios.Remove(usuarioDB);
            _bancoContext.SaveChanges();

            return true;

        }


    }
}
