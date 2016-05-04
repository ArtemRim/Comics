namespace Comics.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cartoons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdUser = c.String(maxLength: 128),
                        Name = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.IdUser)
                .Index(t => t.IdUser);
            
            CreateTable(
                "dbo.CartoonTags",
                c => new
                    {
                        IdTag = c.Int(nullable: false),
                        IdCartoon = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdTag, t.IdCartoon })
                .ForeignKey("dbo.Cartoons", t => t.IdCartoon, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.IdTag, cascadeDelete: true)
                .Index(t => t.IdTag)
                .Index(t => t.IdCartoon);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Information = c.String(),
                        PhotoURL = c.String(maxLength: 1000),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.UserMedals",
                c => new
                    {
                        IdMedal = c.Int(nullable: false),
                        IdUser = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.IdMedal, t.IdUser })
                .ForeignKey("dbo.Medals", t => t.IdMedal, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.IdUser, cascadeDelete: true)
                .Index(t => t.IdMedal)
                .Index(t => t.IdUser);
            
            CreateTable(
                "dbo.Medals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageURL = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        IdAuthor = c.String(maxLength: 128),
                        IdUser = c.String(maxLength: 128),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.IdAuthor)
                .ForeignKey("dbo.AspNetUsers", t => t.IdUser)
                .Index(t => t.IdAuthor)
                .Index(t => t.IdUser);
            
            CreateTable(
                "dbo.DialogTemplates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        URL = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PartDialogs",
                c => new
                    {
                        IdPart = c.Int(nullable: false),
                        IdDialogTemplate = c.Int(nullable: false),
                        PosX = c.Int(nullable: false),
                        PosY = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdPart, t.IdDialogTemplate })
                .ForeignKey("dbo.DialogTemplates", t => t.IdDialogTemplate, cascadeDelete: true)
                .ForeignKey("dbo.Parts", t => t.IdPart, cascadeDelete: true)
                .Index(t => t.IdPart)
                .Index(t => t.IdDialogTemplate);
            
            CreateTable(
                "dbo.Parts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ElementUrl = c.String(),
                        ElementPosX = c.Int(nullable: false),
                        ElementPosY = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdCartoon = c.Int(nullable: false),
                        IdPageTemplate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cartoons", t => t.IdCartoon, cascadeDelete: true)
                .ForeignKey("dbo.PageTemplates", t => t.IdPageTemplate, cascadeDelete: true)
                .Index(t => t.IdCartoon)
                .Index(t => t.IdPageTemplate);
            
            CreateTable(
                "dbo.PageTemplates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        URL = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Voices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdCartoon = c.Int(nullable: false),
                        Mark = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cartoons", t => t.IdCartoon, cascadeDelete: true)
                .Index(t => t.IdCartoon);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Voices", "IdCartoon", "dbo.Cartoons");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Pages", "IdPageTemplate", "dbo.PageTemplates");
            DropForeignKey("dbo.Pages", "IdCartoon", "dbo.Cartoons");
            DropForeignKey("dbo.PartDialogs", "IdPart", "dbo.Parts");
            DropForeignKey("dbo.PartDialogs", "IdDialogTemplate", "dbo.DialogTemplates");
            DropForeignKey("dbo.Comments", "IdUser", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "IdAuthor", "dbo.AspNetUsers");
            DropForeignKey("dbo.Cartoons", "IdUser", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserMedals", "IdUser", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserMedals", "IdMedal", "dbo.Medals");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CartoonTags", "IdTag", "dbo.Tags");
            DropForeignKey("dbo.CartoonTags", "IdCartoon", "dbo.Cartoons");
            DropIndex("dbo.Voices", new[] { "IdCartoon" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Pages", new[] { "IdPageTemplate" });
            DropIndex("dbo.Pages", new[] { "IdCartoon" });
            DropIndex("dbo.PartDialogs", new[] { "IdDialogTemplate" });
            DropIndex("dbo.PartDialogs", new[] { "IdPart" });
            DropIndex("dbo.Comments", new[] { "IdUser" });
            DropIndex("dbo.Comments", new[] { "IdAuthor" });
            DropIndex("dbo.UserMedals", new[] { "IdUser" });
            DropIndex("dbo.UserMedals", new[] { "IdMedal" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.CartoonTags", new[] { "IdCartoon" });
            DropIndex("dbo.CartoonTags", new[] { "IdTag" });
            DropIndex("dbo.Cartoons", new[] { "IdUser" });
            DropTable("dbo.Voices");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PageTemplates");
            DropTable("dbo.Pages");
            DropTable("dbo.Parts");
            DropTable("dbo.PartDialogs");
            DropTable("dbo.DialogTemplates");
            DropTable("dbo.Comments");
            DropTable("dbo.Medals");
            DropTable("dbo.UserMedals");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Tags");
            DropTable("dbo.CartoonTags");
            DropTable("dbo.Cartoons");
        }
    }
}
