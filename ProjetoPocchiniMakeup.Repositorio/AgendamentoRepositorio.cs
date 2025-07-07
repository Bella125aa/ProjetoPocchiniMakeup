using Domain.Entities;
using ProjetoPocchiniMakeup.Dominio.Entidade;
using static Domain.Entities.Agendamento;

namespace DataAccess.Repositorio {

public class AgendamentoRepositorio : BaseRepositorio, IAgendamentoRepositorio
{
    public AgendamentoRepositorio(ProjetoPocchiniMakeupContexto contexto) : base(contexto)
    {
    }

    public int Salvar(Agendamento agendamento)
    {
        _contexto.Agendamento.Add(agendamento);
        _contexto.SaveChanges();

        return agendamento.Id;
    }

    public void Atualizar(Agendamento agendamento)
    {
        _contexto.Agendamento.Update(agendamento);
        _contexto.SaveChanges();
    }

    public Agendamento Obter(int agendamentoId)
    {
        return _contexto.Agendamento
        .Where(u => u.Id == agendamentoId)
        .FirstOrDefault();
    }

    public Agendamento ObterPorEmail(string email)
    {
        return _contexto.Agendamento
        .Where(u => u.Email == email)
        .FirstOrDefault();
    }

    public IEnumerable<Agendamento> Listar(StatusAgendamento status)
    {
        return _contexto.Agendamento.Where(u => u.Status == status).ToList();
    }
 }
}
