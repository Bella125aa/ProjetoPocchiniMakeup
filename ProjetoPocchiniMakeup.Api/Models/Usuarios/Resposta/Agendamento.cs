namespace ProjetoPocchiniMakeup.Api.Models.Resposta
{
    public class AgendamentoResposta
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public string TipoMaquiagem { get; set; }
        public string Nome { get; set; }
        public string Status { get; set; }
        public string Local { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Observacao { get; set; }
    }
}