using ProjetoPocchiniMakeup.Dominio.Entidade;

namespace DataAccess.Repositorio {

public class UsuarioRepositorio : BaseRepositorio, IUsuarioRepositorio
{
    public UsuarioRepositorio(ProjetoPocchiniMakeupContexto contexto) : base(contexto)
    {
    }

    public int Salvar(Usuario usuario)
    {
        _contexto.Usuarios.Add(usuario);
        _contexto.SaveChanges();

        return usuario.ID;
    }

    public void Atualizar(Usuario usuario)
    {
        _contexto.Usuarios.Update(usuario);
        _contexto.SaveChanges();
    }

    public Usuario Obter(int usuarioId)
    {
        return _contexto.Usuarios
        .Where(u => u.ID == usuarioId)
        .Where(u => u.Ativo)
        .FirstOrDefault();
    }

    public Usuario ObterPorEmail(string email)
    {
        return _contexto.Usuarios
        .Where(u => u.Email == email)
        .Where(u => u.Ativo)
        .FirstOrDefault();
    }

    public IEnumerable<Usuario> Listar(bool ativo)
    {
        return _contexto.Usuarios.Where(u => u.Ativo == ativo).ToList();
    }
 }
}
