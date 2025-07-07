using ProjetoPocchiniMakeup.Dominio.Enumeradores;

namespace Domain.Entidade
{
    public class Agendamento
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string TipoMaquiagem { get; set; } = string.Empty;
        public DateTime DataHora { get; set; }
        public string Local { get; set; } = string.Empty;
        public string Observacoes { get; set; } = string.Empty;
        public StatusAgendamento Status { get; set; } = StatusAgendamento.Pendente;

    }

}
