namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig17 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MessageAuthors",
                c => new
                    {
                        MessageAuthorID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Surname = c.String(maxLength: 50),
                        Mail = c.String(maxLength: 50),
                        Subject = c.String(maxLength: 50),
                        Message = c.String(),
                        MessageDate = c.DateTime(nullable: false),
                        ContactStatus = c.Boolean(nullable: false),
                        AuthorID = c.Int(nullable: false),
                        Category_CategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.MessageAuthorID)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryID)
                .ForeignKey("dbo.Authors", t => t.AuthorID, cascadeDelete: true)
                .Index(t => t.AuthorID)
                .Index(t => t.Category_CategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MessageAuthors", "AuthorID", "dbo.Authors");
            DropForeignKey("dbo.MessageAuthors", "Category_CategoryID", "dbo.Categories");
            DropIndex("dbo.MessageAuthors", new[] { "Category_CategoryID" });
            DropIndex("dbo.MessageAuthors", new[] { "AuthorID" });
            DropTable("dbo.MessageAuthors");
        }
    }
}
