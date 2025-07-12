using Domain.Entidade;
using ProjetoPocchiniMakeup.Dominio.Entidade;
using ProjetoPocchiniMakeup.Dominio.Enumeradores;

namespace ProjetoPocchiniMakeup.Aplicacao
{
    public interface IAgendamentoAplicacao
    {
        Task<int> CriarAsync(Agendamento agendamentoDTO);
        Task AtualizarAsync(Agendamento agendamentoDTO);
        Task<IEnumerable<Agendamento>> ListarAsync(StatusAgendamento ativo);
        Task<IEnumerable<Agendamento>> ListarAsync();
        Task<Agendamento> ObterAsync(int agendamentoId);
    }
}
