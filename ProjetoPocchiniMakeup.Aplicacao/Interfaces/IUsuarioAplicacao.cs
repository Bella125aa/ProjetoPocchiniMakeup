using ProjetoPocchiniMakeup.Dominio.Entidade;

namespace ProjetoPocchiniMakeup.Aplicacao
{
    public interface IUsuarioAplicacao
    {
        Task<int> CriarAsync(Usuario usuarioDTO);
        Task AlterarSenhaAsync(Usuario usuarioDTO, string novaSenha);
        Task AtualizarAsync(Usuario usuarioDTO);
        Task DeletarAsync(int usuarioId);
        Task RestaurarAsync(int usuarioId);
        Task <IEnumerable<Usuario>> ListarAsync(bool ativo);
        Task<Usuario> ObterAsync(int usuarioId);
        Task<Usuario> ObterPorEmailAsync(string email);
    }
}
