using System.Threading.Tasks;
using Domain.Entidade;
using Microsoft.EntityFrameworkCore;
using ProjetoPocchiniMakeup.Dominio.Enumeradores;

namespace DataAccess.Repositorio
{

    public class AgendamentoRepositorio : BaseRepositorio, IAgendamentoRepositorio
    {
        public AgendamentoRepositorio(ProjetoPocchiniMakeupContexto contexto) : base(contexto)
        {
        }

        public async Task<int> SalvarAsync(Agendamento agendamento)
        {

            await _contexto.Agendamento.AddAsync(agendamento);
            await _contexto.SaveChangesAsync();

            return agendamento.Id;
        }

        public async Task AtualizarAsync(Agendamento agendamento)
        {

            _contexto.Agendamento.Update(agendamento);
            await _contexto.SaveChangesAsync();
        }

        public async Task<Agendamento> ObterAsync(int agendamentoId)
        {
            return await _contexto.Agendamento
            .Where(u => u.Id == agendamentoId)
            .FirstOrDefaultAsync();
        }

        public async Task<Agendamento> ObterPorEmailAsync(string email)
        {
            return await _contexto.Agendamento
            .Where(u => u.Email == email)
            .FirstOrDefaultAsync();
        }

        public async Task<List<Agendamento>> ObterAgendamentosPorDataAsync(DateTime data)
        {
            return await _contexto.Agendamento
            .Where(a => a.DataHora.Date == data.Date)
            .ToListAsync();
        }

        public async Task<IEnumerable<Agendamento>> ListarPorStatusAsync(StatusAgendamento status)
        {
            return await _contexto.Agendamento.Where(a => a.Status == status).ToListAsync();
        }

        public async Task<IEnumerable<Agendamento>> ListarPorUsuarioAsync(int usuarioId, StatusAgendamento status)
        {
            return await _contexto.Agendamento.Where(a => a.UsuarioId == usuarioId && a.Status == status).ToListAsync();
        }

        public async Task<IEnumerable<Agendamento>> ListarTodosAsync()
        {
            return await _contexto.Agendamento.Where(a => a.Status == StatusAgendamento.Marcado).ToListAsync();
        }
    }
}
