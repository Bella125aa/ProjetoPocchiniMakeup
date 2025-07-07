using ProjetoPocchiniMakeup.Dominio.Entidade;

namespace ProjetoPocchiniMakeup.Servicos.Interfaces
{
    public interface IJsonPlaceHolderServico
    {
        Task<List<servicoNoiva>> ListarServicos();
    }
}