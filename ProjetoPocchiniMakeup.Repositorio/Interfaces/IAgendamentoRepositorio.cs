using Domain.Entities;
using ProjetoPocchiniMakeup.Dominio.Entidade;
using static Domain.Entities.Agendamento;

public interface IAgendamentoRepositorio
{
    int Salvar(Agendamento agendamento);
    void Atualizar(Agendamento agendamento);
    Agendamento Obter(int agendamentoId);
    Agendamento ObterPorEmail(string email);
    IEnumerable<Agendamento> Listar(StatusAgendamento ativo);
}

