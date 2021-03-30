namespace ElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Note", "CategoryId", "dbo.Category");
            DropIndex("dbo.Note", new[] { "CategoryId" });
            DropColumn("dbo.Note", "CategoryId");
            DropTable("dbo.Category");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        CategoryName = c.String(nullable: false),
                        SectionName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            AddColumn("dbo.Note", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Note", "CategoryId");
            AddForeignKey("dbo.Note", "CategoryId", "dbo.Category", "CategoryId", cascadeDelete: true);
        }
    }
}
