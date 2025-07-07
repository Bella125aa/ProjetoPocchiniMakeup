using Domain.Entidade;
using ProjetoPocchiniMakeup.Dominio.Enumeradores;

public interface IAgendamentoRepositorio
{
    Task<int> SalvarAsync(Agendamento agendamento);
    Task AtualizarAsync(Agendamento agendamento);
    Task<Agendamento> ObterAsync(int agendamentoId);
    Task<List<Agendamento>> ObterAgendamentosPorDataAsync(DateTime data);
    Task<IEnumerable<Agendamento>> ListarAsync(StatusAgendamento ativo);
}

