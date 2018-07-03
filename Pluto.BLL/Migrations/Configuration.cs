namespace Pluto.BLL.Migrations
{
    using Pluto.BLL.Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Pluto.BLL.DAL.PlutoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Pluto.BLL.DAL.PlutoContext";
        }

        protected override void Seed(Pluto.BLL.DAL.PlutoContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var subjects = new List<Subject>
            {
                new Subject{ Name = "Analízis", Credit = 6 },
                new Subject{ Name = "Bevezetés  a számításelméletbe", Credit = 4 },
                new Subject{ Name = "Fizika", Credit = 4 },
                new Subject{ Name = "Digitális technika", Credit = 7 },
                new Subject{ Name = "A programozás alapjai", Credit = 7 }
            };

            subjects.ForEach(s => context.Subjects.AddOrUpdate(s));

            context.SaveChanges();

            var terms = new List<Term>();
            for (var i = 1; i < 5; i++)
            {
                terms.Add(new Term() { Name = i + ". term", IsActive = (i % 2 == 0 ? true : false) });
            }

            terms.ForEach(t => context.Terms.AddOrUpdate(t));

            context.SaveChanges();
        }
    }
}
