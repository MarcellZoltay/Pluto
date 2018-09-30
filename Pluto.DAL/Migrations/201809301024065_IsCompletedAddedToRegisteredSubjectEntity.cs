namespace Pluto.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsCompletedAddedToRegisteredSubjectEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegisteredSubject", "IsCompleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RegisteredSubject", "IsCompleted");
        }
    }
}
