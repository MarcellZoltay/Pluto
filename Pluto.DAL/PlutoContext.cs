using Pluto.DAL.Entities;
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<SubjectEntity>().ToTable("Subject");
            modelBuilder.Entity<TermEntity>().ToTable("Term");
        }
    }
}
