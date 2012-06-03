using System.Data.Entity;
using Dominio;

namespace Repositorio
{
    public class DBProduto:DbContext
    {
        public DBProduto():base("CadastroDeProdutos")
        {
            
        }

        public DbSet<Produto> Produtos { get; set; }
        
        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<ListaDeProduto> ListaDeProdutos { get; set; }
    }
}
