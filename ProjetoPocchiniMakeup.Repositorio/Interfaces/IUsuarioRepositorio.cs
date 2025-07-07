using ProjetoPocchiniMakeup.Dominio.Entidade;

public interface IUsuarioRepositorio
{
    int Salvar(Usuario usuario);
    void Atualizar(Usuario usuario);
    Usuario Obter(int usuarioId);
    Usuario ObterPorEmail(string email);
    IEnumerable<Usuario> Listar(bool ativo);
}
