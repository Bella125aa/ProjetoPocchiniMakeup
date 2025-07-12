using ProjetoPocchiniMakeup.Dominio.Enumeradores;

namespace ProjetoPocchiniMakeup.Api.Models.Requisicao
{
    public class AgendamentoCriar
    {
        public DateTime DataHora { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Observacao { get; set; }
        public string Telefone { get; set; }
        public string TipoMaquiagem { get; set; }
        public string Local { get; set; }

    }
}