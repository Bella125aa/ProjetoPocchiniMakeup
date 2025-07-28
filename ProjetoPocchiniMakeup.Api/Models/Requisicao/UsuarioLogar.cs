namespace ProjetoPocchiniMakeup.Api.Models.Requisicao
{
    public class UsuarioLogar
    {
        public bool? EhAdmin { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
