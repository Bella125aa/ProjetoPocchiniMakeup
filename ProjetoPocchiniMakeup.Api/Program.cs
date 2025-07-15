using DataAccess.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjetoPocchiniMakeup.Aplicacao;
using ProjetoPocchiniMakeup.Servicos;
using ProjetoPocchiniMakeup.Servicos.Interfaces;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IUsuarioAplicacao, UsuarioAplicacao>();
builder.Services.AddScoped<IAgendamentoAplicacao, AgendamentoAplicacao>();
builder.Services.AddScoped<IAiService, AiService>();

//Adicione as interfaces de banco de dados
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<IAgendamentoRepositorio, AgendamentoRepositorio>();



builder.Services.AddControllers();

// Adicionar o serviço de banco de dados
builder.Services.AddDbContext<ProjetoPocchiniMakeupContexto>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:3000") // endereço do seu frontend local
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
