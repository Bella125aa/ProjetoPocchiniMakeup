using ProjetoPocchiniMakeup.Dominio.Entidade;

public interface IUsuarioRepositorio
{
    Task<int> SalvarAsync(Usuario usuario);
    Task AtualizarAsync(Usuario usuario);
    Task<Usuario> ObterAsync(int usuarioId);
    Task<Usuario> ObterPorEmailAsync(string email);
    Task<IEnumerable<Usuario>> Listar(bool ativo);
}
