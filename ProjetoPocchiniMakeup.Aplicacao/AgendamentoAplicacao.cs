using System.Threading.Tasks;
using DataAccess.Repositorio;
using Domain.Entidade;
using ProjetoPocchiniMakeup.Aplicacao;
using ProjetoPocchiniMakeup.Dominio.Entidade;
using ProjetoPocchiniMakeup.Dominio.Enumeradores;
using static Domain.Entidade.Agendamento;


namespace ProjetoPocchiniMakeup.Aplicacao
{
    public class AgendamentoAplicacao : IAgendamentoAplicacao
    {
        readonly IAgendamentoRepositorio _agendamentoRepositorio;

        public AgendamentoAplicacao(IAgendamentoRepositorio agendamentoRepositorio)
        {
            _agendamentoRepositorio = agendamentoRepositorio;
        }

        public async Task<int> CriarAsync(Agendamento novoAgendamento)
        {
            if (novoAgendamento == null)
                throw new Exception("Agendamento não pode ser vazio");

            List<Agendamento> agendamentosExistentes = await _agendamentoRepositorio.ObterAgendamentosPorDataAsync(novoAgendamento.DataHora);

            if (agendamentosExistentes.Any())
            {
                foreach (var agendamento in agendamentosExistentes)
                {
                    if (agendamento.DataHora.TimeOfDay == novoAgendamento.DataHora.TimeOfDay)
                    {
                        throw new Exception("Já existe um agendamento confirmado para esta data e hora.");
                    }
                }
            }

            return await _agendamentoRepositorio.SalvarAsync(novoAgendamento);
        }

        public async Task AtualizarAsync(Agendamento agendamento)
        {
            var agendamentoDominio = await _agendamentoRepositorio.ObterAsync(agendamento.Id);

            if (agendamentoDominio == null)
                throw new Exception("Agendamento não encontrado");

            await _agendamentoRepositorio.AtualizarAsync(agendamento);
        }

        public async Task<Agendamento> ObterAsync(int agendamentoId)
        {
            var agendamentoDominio = await _agendamentoRepositorio.ObterAsync(agendamentoId);

            if (agendamentoDominio == null)
                throw new Exception("Agendamento não encontrado");

            return agendamentoDominio;
        }

        public async Task<IEnumerable<Agendamento>> ListarAsync(StatusAgendamento status)
        {
            return await _agendamentoRepositorio.ListarAsync(status);
        }

    }
}