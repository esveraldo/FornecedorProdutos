namespace Dev.Infra.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class EmptyMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Enderecos",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Logradouro = c.String(nullable: false, maxLength: 200, unicode: false),
                        Numero = c.String(nullable: false, maxLength: 10, unicode: false),
                        Complemento = c.String(nullable: false, maxLength: 50, unicode: false),
                        Cep = c.String(nullable: false, maxLength: 8, unicode: false),
                        Bairro = c.String(nullable: false, maxLength: 200, unicode: false),
                        Cidade = c.String(nullable: false, maxLength: 200, unicode: false),
                        Estado = c.String(nullable: false, maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fornecedores", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Fornecedores",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 200, unicode: false),
                        Documento = c.String(maxLength: 20, unicode: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "IX_Documento",
                                    new AnnotationValues(oldValue: null, newValue: "IndexAnnotation: { IsUnique: True }")
                                },
                            }),
                        TipoFornecedor = c.Int(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Produtos",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 200, unicode: false),
                        Descricao = c.String(nullable: false, maxLength: 200, unicode: false),
                        Imagem = c.String(nullable: false, maxLength: 200, unicode: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DataCadastro = c.DateTime(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        FornecedorId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fornecedores", t => t.FornecedorId)
                .Index(t => t.FornecedorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtos", "FornecedorId", "dbo.Fornecedores");
            DropForeignKey("dbo.Enderecos", "Id", "dbo.Fornecedores");
            DropIndex("dbo.Produtos", new[] { "FornecedorId" });
            DropIndex("dbo.Enderecos", new[] { "Id" });
            DropTable("dbo.Produtos");
            DropTable("dbo.Fornecedores",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "Documento",
                        new Dictionary<string, object>
                        {
                            { "IX_Documento", "IndexAnnotation: { IsUnique: True }" },
                        }
                    },
                });
            DropTable("dbo.Enderecos");
        }
    }
}
