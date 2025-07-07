using Domain.Entidade;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoPocchiniMakeup.Dominio.Entidade;

namespace ProjetoPocchiniMakeup.Repositorio.Configuracoes
{
    public class AgendamentoConfiguracoes : IEntityTypeConfiguration<Agendamento>
    {
        public void Configure(EntityTypeBuilder<Agendamento> builder)
        {
            builder.ToTable("Agendamento").HasKey(x => x.Id);

            builder.Property(nameof(Agendamento.Id)).HasColumnName("AgendamentoId");
            builder.Property(nameof(Agendamento.Nome)).HasColumnName("Nome").IsRequired(true);
            builder.Property(nameof(Agendamento.Email)).HasColumnName("Email").IsRequired(true);
            builder.Property(nameof(Agendamento.Telefone)).HasColumnName("Telefone").IsRequired(true);
            builder.Property(nameof(Agendamento.TipoMaquiagem)).HasColumnName("TipoMaquiagem").IsRequired(true);
            builder.Property(nameof(Agendamento.DataHora)).HasColumnName("DataHora").IsRequired(true);
            builder.Property(nameof(Agendamento.Local)).HasColumnName("Local").IsRequired(true);
            builder.Property(nameof(Agendamento.Observacoes)).HasColumnName("Observacoes").IsRequired(true);
            builder.Property(nameof(Agendamento.Status)).HasColumnName("Status").IsRequired(true);
        }
    }
}