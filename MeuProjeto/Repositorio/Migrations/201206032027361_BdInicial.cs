namespace Repositorio.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class BdInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Produtoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Categoria_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Categorias", t => t.Categoria_Id)
                .Index(t => t.Categoria_Id);
            
            CreateTable(
                "Categorias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "ListaDeProdutoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "ListaDeProdutoProdutoes",
                c => new
                    {
                        ListaDeProduto_Id = c.Int(nullable: false),
                        Produto_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ListaDeProduto_Id, t.Produto_Id })
                .ForeignKey("ListaDeProdutoes", t => t.ListaDeProduto_Id, cascadeDelete: true)
                .ForeignKey("Produtoes", t => t.Produto_Id, cascadeDelete: true)
                .Index(t => t.ListaDeProduto_Id)
                .Index(t => t.Produto_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("ListaDeProdutoProdutoes", new[] { "Produto_Id" });
            DropIndex("ListaDeProdutoProdutoes", new[] { "ListaDeProduto_Id" });
            DropIndex("Produtoes", new[] { "Categoria_Id" });
            DropForeignKey("ListaDeProdutoProdutoes", "Produto_Id", "Produtoes");
            DropForeignKey("ListaDeProdutoProdutoes", "ListaDeProduto_Id", "ListaDeProdutoes");
            DropForeignKey("Produtoes", "Categoria_Id", "Categorias");
            DropTable("ListaDeProdutoProdutoes");
            DropTable("ListaDeProdutoes");
            DropTable("Categorias");
            DropTable("Produtoes");
        }
    }
}
