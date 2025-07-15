using ProjetoPocchiniMakeup.Dominio.Entidade;

namespace ProjetoPocchiniMakeup.Servicos.Interfaces
{
    public interface IAiService
    {
        Task<string> GetAiResponseAsync(string prompt);
    }
}