namespace Pluto.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRegisteredSubject : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RegisteredSubject",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectId = c.Int(nullable: false),
                        TermId = c.Int(nullable: false),
                        Name = c.String(),
                        Credit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subject", t => t.SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.Term", t => t.TermId, cascadeDelete: true)
                .Index(t => t.SubjectId)
                .Index(t => t.TermId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RegisteredSubject", "TermId", "dbo.Term");
            DropForeignKey("dbo.RegisteredSubject", "SubjectId", "dbo.Subject");
            DropIndex("dbo.RegisteredSubject", new[] { "TermId" });
            DropIndex("dbo.RegisteredSubject", new[] { "SubjectId" });
            DropTable("dbo.RegisteredSubject");
        }
    }
}
