using System.Collections.Generic;

namespace Dominio
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Categoria Categoria { get; set; }

        public virtual ICollection<ListaDeProduto> ListaDeProdutos { get; set; }
    }
}
