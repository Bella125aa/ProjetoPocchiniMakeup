public abstract class BaseRepositorio
{
    protected readonly ProjetoPocchiniMakeupContexto _contexto;

    protected BaseRepositorio(ProjetoPocchiniMakeupContexto contexto)
    {
        _contexto = contexto;
    }
}