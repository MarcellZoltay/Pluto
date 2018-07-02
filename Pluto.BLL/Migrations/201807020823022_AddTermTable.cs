namespace Pluto.BLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTermTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Term",
                c => new
                    {
                        TermId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TermId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Term");
        }
    }
}
