namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig18 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MessageAuthors", "Category_CategoryID", "dbo.Categories");
            DropIndex("dbo.MessageAuthors", new[] { "Category_CategoryID" });
            DropColumn("dbo.MessageAuthors", "Category_CategoryID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MessageAuthors", "Category_CategoryID", c => c.Int());
            CreateIndex("dbo.MessageAuthors", "Category_CategoryID");
            AddForeignKey("dbo.MessageAuthors", "Category_CategoryID", "dbo.Categories", "CategoryID");
        }
    }
}
