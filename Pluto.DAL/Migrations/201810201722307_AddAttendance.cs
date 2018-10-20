namespace Pluto.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAttendance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegisteredSubjectId = c.Int(nullable: false),
                        Name = c.String(),
                        IsAttended = c.Boolean(nullable: false),
                        Date = c.DateTime(nullable: false),
                        StartTime = c.Time(nullable: false, precision: 7),
                        EndTime = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RegisteredSubjects", t => t.RegisteredSubjectId, cascadeDelete: true)
                .Index(t => t.RegisteredSubjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendances", "RegisteredSubjectId", "dbo.RegisteredSubjects");
            DropIndex("dbo.Attendances", new[] { "RegisteredSubjectId" });
            DropTable("dbo.Attendances");
        }
    }
}
