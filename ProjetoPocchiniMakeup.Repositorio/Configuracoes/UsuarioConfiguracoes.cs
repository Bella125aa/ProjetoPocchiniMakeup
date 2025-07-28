using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoPocchiniMakeup.Dominio.Entidade;

namespace ProjetoPocchiniMakeup.Repositorio.Configuracoes
{
    public class UsuarioConfiguracoes : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario").HasKey(x => x.UsuarioId);

            builder.Property(nameof(Usuario.UsuarioId)).HasColumnName("UsuarioId");
            builder.Property(nameof(Usuario.Nome)).HasColumnName("Nome").IsRequired(true);
            builder.Property(nameof(Usuario.Email)).HasColumnName("Email").IsRequired(true);
            builder.Property(nameof(Usuario.Senha)).HasColumnName("Senha").IsRequired(true);
            builder.Property(nameof(Usuario.Ativo)).HasColumnName("Ativo").IsRequired(true);

            builder.HasMany(u => u.Agendamentos)
                   .WithOne(a => a.Usuario)
                   .HasForeignKey("UsuarioId");
        }
    }
}