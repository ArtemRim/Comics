namespace Comics.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class somechas2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PageTemplates", "Parts");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PageTemplates", "Parts", c => c.String());
        }
    }
}
