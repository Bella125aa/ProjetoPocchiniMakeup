using DataAccess.Repositorio;
using ProjetoPocchiniMakeup.Aplicacao;
using ProjetoPocchiniMakeup.Dominio.Entidade;


namespace ProjetoPocchiniMakeup.Aplicacao
{
    public class UsuarioAplicacao : IUsuarioAplicacao
    {
        readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioAplicacao(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public int Criar(Usuario usuario)
        {
            if (usuario == null)
                throw new Exception("Usuario não pode ser vazio");

            if (string.IsNullOrEmpty(usuario.Senha))
                throw new Exception("Senha não pode ser vazio");

            ValidarInformacoesUsuario(usuario);

            return _usuarioRepositorio.Salvar(usuario);
        }


        public void Atualizar(Usuario usuario)
        {
            var usuarioDominio = _usuarioRepositorio.Obter(usuario.ID);

            if (usuarioDominio == null)
                throw new Exception("Usuario não encontrado");

            ValidarInformacoesUsuario(usuario);

            usuarioDominio.Nome = usuario.Nome;
            usuarioDominio.Email = usuario.Email;

            _usuarioRepositorio.Atualizar(usuarioDominio);
        }

        public void AlterarSenha(Usuario usuario, string senhaAntiga)

        {
            var usuarioDominio = _usuarioRepositorio.Obter(usuario.ID);

            if (usuarioDominio == null)
                throw new Exception("Usuario não encontrado");

            if (usuarioDominio.Senha != senhaAntiga)
                throw new Exception("Senha antiga inválida");

            usuarioDominio.Senha = usuario.Senha;

            _usuarioRepositorio.Atualizar(usuarioDominio);
        }

        public Usuario Obter(int usuarioId)
        {
            var usuarioDominio = _usuarioRepositorio.Obter(usuarioId);

            if (usuarioDominio == null)
                throw new Exception("Usuario não encontrado");

            return usuarioDominio;
        }

        public Usuario ObterPorEmail(string email)
        {
            var usuarioDominio = _usuarioRepositorio.ObterPorEmail(email);

            if (usuarioDominio == null)
                throw new Exception("Usuário não encontrado");

            return usuarioDominio;
        }

        public void Deletar(int usuarioId)
        {
            var usuarioDominio = _usuarioRepositorio.Obter(usuarioId);

            if (usuarioDominio == null)
                throw new Exception("Usuário não encontrado");

            usuarioDominio.Deletar();

            _usuarioRepositorio.Atualizar(usuarioDominio);
        }

        public void Restaurar(int usuarioId)
        {
            var usuarioDominio = _usuarioRepositorio.Obter(usuarioId);

            if (usuarioDominio == null)
                throw new Exception("Usuario não encontrado");

            usuarioDominio.Restaurar();

            _usuarioRepositorio.Atualizar(usuarioDominio);
        }

        public IEnumerable<Usuario> Listar(bool ativo)
        {
            return _usuarioRepositorio.Listar(ativo);
        }


        #region Util


        private static void ValidarInformacoesUsuario(Usuario usuario)
        {
            if (string.IsNullOrEmpty(usuario.Email))
                throw new Exception("E-mail não pode ser vazio");

            if (string.IsNullOrEmpty(usuario.Nome))
                throw new Exception("Nome não pode ser vazio");
        }

        #endregion
    }
}