using ProjetoPocchiniMakeup.Dominio.Enumeradores;

namespace ProjetoPocchiniMakeup.Api.Models.Resposta
{
    public class UsuarioResposta
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public TipoUsuarioEnum TipoUsuario { get; set; }
    }
}