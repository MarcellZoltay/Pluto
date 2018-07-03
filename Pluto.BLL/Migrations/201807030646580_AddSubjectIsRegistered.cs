namespace Pluto.BLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSubjectIsRegistered : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subject", "IsRegistered", c => c.Boolean(nullable: false, defaultValue: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Subject", "IsRegistered");
        }
    }
}
