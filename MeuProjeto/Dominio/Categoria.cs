using System.Collections.Generic;

namespace Dominio
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public virtual IEnumerable<Produto> Produtos { get; set; }
    }
}
