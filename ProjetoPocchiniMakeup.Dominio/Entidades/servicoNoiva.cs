using System.Dynamic;

namespace ProjetoPocchiniMakeup.Dominio.Entidade
{

    public class servicoNoiva
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public bool Completa { get; set; }

        public servicoNoiva()
        {
            Completa = false;
        }
    }
}