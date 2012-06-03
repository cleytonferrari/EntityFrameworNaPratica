using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Dominio;
using Repositorio;

namespace Aplicacao
{
    public class ProdutoAplicacao
    {
        public DBProduto Banco { get; set; }

        public ProdutoAplicacao()
        {
            Banco = new DBProduto();
        }

        public void Salvar(Produto produto)
        {
            produto.Categoria = Banco.Categorias.ToList().Where(x => x.Id == produto.Categoria.Id).FirstOrDefault();
            Banco.Produtos.Add(produto);
            Banco.SaveChanges();
        }

        public IEnumerable<Produto> Listar()
        {
            return Banco.Produtos.Include(x=>x.Categoria).ToList();
        }

        public void Alterar(Produto produto)
        {
            Produto produtoSalvar = Banco.Produtos.Where(x => x.Id == produto.Id).First();
            produtoSalvar.Nome = produto.Nome;
            Banco.SaveChanges();
        }

        public void Excluir(int id)
        {
            Produto produtoExcluir = Banco.Produtos.First(x => x.Id == id);
            Banco.Set<Produto>().Remove(produtoExcluir);
            Banco.SaveChanges();
        }

    }
}
