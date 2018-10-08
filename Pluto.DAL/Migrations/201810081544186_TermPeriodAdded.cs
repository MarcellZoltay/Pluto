namespace Pluto.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TermPeriodAdded : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.RegisteredSubject", newName: "RegisteredSubjects");
            RenameTable(name: "dbo.Subject", newName: "Subjects");
            RenameTable(name: "dbo.Term", newName: "Terms");
            AddColumn("dbo.Terms", "StartDate", c => c.DateTime());
            AddColumn("dbo.Terms", "EndDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Terms", "EndDate");
            DropColumn("dbo.Terms", "StartDate");
            RenameTable(name: "dbo.Terms", newName: "Term");
            RenameTable(name: "dbo.Subjects", newName: "Subject");
            RenameTable(name: "dbo.RegisteredSubjects", newName: "RegisteredSubject");
        }
    }
}
