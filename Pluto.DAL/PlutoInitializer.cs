using Pluto.DAL.Entities;
using Pluto.DAL.Entities.SubjectEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluto.DAL
{
    class PlutoInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<PlutoContext>
    {
        protected override void Seed(PlutoContext context)
        {
            var subjects = new List<SubjectEntity>
            {
                new SubjectEntity{ Name = "Analízis 1", Credit = 6 },
                new SubjectEntity{ Name = "Bevezetés a számításelméletbe 1", Credit = 4 },
                new SubjectEntity{ Name = "Fizika 1i", Credit = 4 },
                new SubjectEntity{ Name = "Digitális technika", Credit = 7 },
                new SubjectEntity{ Name = "A programozás alapjai 1", Credit = 7 }
            };

            subjects.ForEach(s => context.Subjects.Add(s));

            context.SaveChanges();

            var terms = new List<TermEntity>();
            for (var i = 1; i < 5; i++)
            {
                terms.Add(new TermEntity() { Name = i + ". term", IsActive = (i % 2 == 0 ? true : false) });
            }

            terms.ForEach(t => context.Terms.Add(t));

            context.SaveChanges();
        }
    }
}
