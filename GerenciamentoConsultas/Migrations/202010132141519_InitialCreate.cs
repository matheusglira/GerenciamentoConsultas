namespace GerenciamentoConsultas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TipoExame",
                c => new
                    {
                        TipoExameId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        NmTipoExame = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TipoExameId);
            
            CreateTable(
                "dbo.CadastroExame",
                c => new
                    {
                        CadastroExameId = c.Int(nullable: false, identity: true),
                        NomeExame = c.String(nullable: false),
                        Observacao = c.String(),
                        TipoExameid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CadastroExameId)
                .ForeignKey("dbo.TipoExame", t => t.TipoExameid, cascadeDelete: true)
                .Index(t => t.TipoExameid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CadastroExame", "TipoExameid", "dbo.TipoExame");
            DropIndex("dbo.CadastroExame", new[] { "TipoExameid" });
            DropTable("dbo.CadastroExame");
            DropTable("dbo.TipoExame");
        }
    }
}
