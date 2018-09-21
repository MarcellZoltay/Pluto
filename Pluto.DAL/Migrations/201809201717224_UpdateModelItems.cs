namespace Pluto.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModelItems : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegisteredSubject", "IsClosed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Subject", "ActualRegisteredSubjectId", c => c.Int(nullable: false));
            AddColumn("dbo.Term", "IsClosed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Term", "IsClosed");
            DropColumn("dbo.Subject", "ActualRegisteredSubjectId");
            DropColumn("dbo.RegisteredSubject", "IsClosed");
        }
    }
}
