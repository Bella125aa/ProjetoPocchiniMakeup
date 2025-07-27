using Domain.Entidade;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProjetoPocchiniMakeup.Dominio.Entidade;
using ProjetoPocchiniMakeup.Repositorio.Configuracoes;

public class ProjetoPocchiniMakeupContexto : DbContext
{
    private readonly DbContextOptions _options;


    public DbSet<Usuario> Usuarios { get; set; }
    
    public DbSet<Agendamento> Agendamento { get; set; }

    public ProjetoPocchiniMakeupContexto()
    { }

    public ProjetoPocchiniMakeupContexto(DbContextOptions options) : base(options)
    {
        _options = options;
    }

    /// <summary>
    /// Configura as opções de conexão com o banco de dados.
    /// </summary>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (_options == null)
            optionsBuilder.UseSqlite(@"Filename=../ProjetoPocchiniMakeup.Repositorio\projetoPocchiniMakeup.sqlite;");
    }

    /// <summary>
    /// Aplica as configurações de entidade para o modelo do banco de dados.
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsuarioConfiguracoes());
        modelBuilder.ApplyConfiguration(new AgendamentoConfiguracoes());
    }
}
