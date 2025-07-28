
using ProjetoPocchiniMakeup.Dominio.Enumeradores;

namespace ProjetoPocchiniMakeup.Api.Models.Requisicao
{

    public class UsuarioCriar
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public TipoUsuarioEnum? TipoUsuario { get; set; }
    }
}