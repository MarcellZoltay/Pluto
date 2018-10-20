using Pluto.DAL.Entities;
using Pluto.DAL.Entities.RegisteredSubjectEntities;
using Pluto.DAL.Entities.SubjectEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluto.DAL
{
    public class PlutoContext : DbContext
    {
        public PlutoContext()
        {
            Database.SetInitializer(new PlutoInitializer());
        }

        public DbSet<SubjectEntity> Subjects { get; set; }
        public DbSet<TermEntity> Terms { get; set; }
        public DbSet<RegisteredSubjectEntity> RegisteredSubjects { get; set; }
        public DbSet<AttendanceEntity> Attendances { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubjectEntity>().ToTable("Subjects");
            modelBuilder.Entity<TermEntity>().ToTable("Terms");
            modelBuilder.Entity<RegisteredSubjectEntity>().ToTable("RegisteredSubjects");
            modelBuilder.Entity<AttendanceEntity>().ToTable("Attendances");
        }
    }
}
