using ProjetoPocchiniMakeup.Dominio.Enumeradores;

namespace ProjetoPocchiniMakeup.Api.Models.Requisicao
{
    public class AgendamentoAtualizar
    {
        public int agendamentoId { get; set; }
        public StatusAgendamento Status { get; set; }

    }
}