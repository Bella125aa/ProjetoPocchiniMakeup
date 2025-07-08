using Microsoft.EntityFrameworkCore;
using ProjetoPocchiniMakeup.Dominio.Entidade;

namespace DataAccess.Repositorio
{

    public class UsuarioRepositorio : BaseRepositorio, IUsuarioRepositorio
    {
        public UsuarioRepositorio(ProjetoPocchiniMakeupContexto contexto) : base(contexto)
        {
        }

        public async Task<int> SalvarAsync(Usuario usuario)
        {
            await _contexto.Usuarios.AddAsync(usuario);
            _contexto.SaveChanges();

            return usuario.ID;
        }

        public async Task AtualizarAsync(Usuario usuario)
        {
            _contexto.Usuarios.Update(usuario);
            await _contexto.SaveChangesAsync();
        }

        public async Task<Usuario> ObterAsync(int usuarioId)
        {
            return await _contexto.Usuarios
            .Where(u => u.ID == usuarioId)
            .Where(u => u.Ativo)
            .FirstOrDefaultAsync();
        }

        public async Task<Usuario> ObterPorEmailAsync(string email)
        {
            return await _contexto.Usuarios
            .Where(u => u.Email == email)
            .Where(u => u.Ativo)
            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Usuario>> Listar(bool ativo)
        {
            return await _contexto.Usuarios.Where(u => u.Ativo == ativo).ToListAsync();
        }
    }
}
