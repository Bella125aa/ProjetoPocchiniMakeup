using Domain.Entidade;
using ProjetoPocchiniMakeup.Dominio.Enumeradores;

namespace ProjetoPocchiniMakeup.Dominio.Entidade
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public TipoUsuarioEnum TipoUsuario { get; set; }
        public List<Agendamento> Agendamentos { get; set; }

        public Usuario()
        {
            Ativo = true;
        }

        public void Deletar()
        {
            Ativo = false;
        }

        public void Restaurar()
        {
            Ativo = true;
        }
    }
}