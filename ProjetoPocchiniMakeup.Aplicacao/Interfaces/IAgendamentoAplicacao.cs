using Domain.Entidade;
using ProjetoPocchiniMakeup.Dominio.Entidade;
using ProjetoPocchiniMakeup.Dominio.Enumeradores;

namespace ProjetoPocchiniMakeup.Aplicacao
{
    public interface IAgendamentoAplicacao
    {
        Task<int> CriarAsync(Agendamento agendamentoDTO);
        Task AtualizarAsync(Agendamento agendamentoDTO);
        Task<IEnumerable<Agendamento>> ListarPorStatusAsync(StatusAgendamento ativo);
        Task<IEnumerable<Agendamento>> ListarPorUsuarioAsync(int usuarioId, StatusAgendamento ativo);
        Task<IEnumerable<Agendamento>> ListarTodosAsync();
        Task<Agendamento> ObterAsync(int agendamentoId);
    }
}
