using Pluto.BLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluto.BLL.DAL
{
    public class PlutoInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<PlutoContext>
    {
        protected override void Seed(PlutoContext context)
        {
            var subjects = new List<Subject>
            {
                new Subject{ Name = "Analízis", Credit = 6 },
                new Subject{ Name = "Bevezetés  a számításelméletbe", Credit = 4 },
                new Subject{ Name = "Fizika", Credit = 4 },
                new Subject{ Name = "Digitális technika", Credit = 7 },
                new Subject{ Name = "A programozás alapjai", Credit = 7 }
            };

            subjects.ForEach(s => context.Subjects.Add(s));

            context.SaveChanges();

            var terms = new List<Term>();
            for (var i=1; i<5; i++)
            {
                terms.Add(new Term() { Name = i + ". term", IsActive = (i%2 == 0 ? true : false) });
            }

            terms.ForEach(t => context.Terms.Add(t));

            context.SaveChanges();
        }
    }
}
