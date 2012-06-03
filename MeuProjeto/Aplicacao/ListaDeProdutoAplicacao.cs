using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Dominio;
using Repositorio;

namespace Aplicacao
{
    public class ListaDeProdutoAplicacao
    {
        public DBProduto Banco { get; set; }

        public ListaDeProdutoAplicacao()
        {
            Banco = new DBProduto();
        }

        public void Salvar(ListaDeProduto listaDeProduto)
        {
            listaDeProduto.Produtos =
                listaDeProduto.Produtos.Select(produto => Banco.Produtos.FirstOrDefault(x => x.Id == produto.Id)).ToList();
            Banco.ListaDeProdutos.Add(listaDeProduto);
            Banco.SaveChanges();
        }

        public IEnumerable<ListaDeProduto> Listar()
        {
            return Banco.ListaDeProdutos
                .Include(x => x.Produtos)
                .Include(x => x.Produtos.Select(c => c.Categoria))
                .ToList();
        }

        public void Alterar(ListaDeProduto listaDeProduto)
        {
            ListaDeProduto listaSalvar = Banco.ListaDeProdutos.Where(x=>x.Id == listaDeProduto.Id).First();
            listaSalvar.Produtos =
                listaDeProduto.Produtos.Select(produto => Banco.Produtos.FirstOrDefault(x => x.Id == produto.Id)).ToList();
            listaSalvar.Descricao = listaDeProduto.Descricao;
            Banco.SaveChanges();
        }

        public void Excluir(int id)
        {
            ListaDeProduto listaExcluir = Banco.ListaDeProdutos.Where(x => x.Id == id).First();
            listaExcluir.Produtos = null;
            Banco.Set<ListaDeProduto>().Remove(listaExcluir);
            Banco.SaveChanges();
        }

    }
}
