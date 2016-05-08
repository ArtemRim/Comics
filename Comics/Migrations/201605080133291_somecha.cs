namespace Comics.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class somecha : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Parts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Left = c.Int(nullable: false),
                        Right = c.Int(nullable: false),
                        Top = c.Int(nullable: false),
                        Bottom = c.Int(nullable: false),
                        Width = c.Int(nullable: false),
                        Height = c.Int(nullable: false),
                        IdPageTemplate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PageTemplates", t => t.IdPageTemplate, cascadeDelete: true)
                .Index(t => t.IdPageTemplate);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parts", "IdPageTemplate", "dbo.PageTemplates");
            DropIndex("dbo.Parts", new[] { "IdPageTemplate" });
            DropTable("dbo.Parts");
        }
    }
}
