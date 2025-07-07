using ProjetoPocchiniMakeup.Dominio.Entidade;

namespace ProjetoPocchiniMakeup.Aplicacao
{
    public interface IUsuarioAplicacao
    {
        int Criar(Usuario usuarioDTO);
        void AlterarSenha(Usuario usuarioDTO, string novaSenha);
        void Atualizar(Usuario usuarioDTO);
        void Deletar(int usuarioId);
        void Restaurar(int usuarioId);
        IEnumerable<Usuario> Listar(bool ativo);
        Usuario Obter(int usuarioId);
        Usuario ObterPorEmail(string email);
    }
}
