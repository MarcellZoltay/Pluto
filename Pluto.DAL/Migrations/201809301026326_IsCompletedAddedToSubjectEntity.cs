namespace Pluto.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsCompletedAddedToSubjectEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subject", "IsCompleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Subject", "IsCompleted");
        }
    }
}
