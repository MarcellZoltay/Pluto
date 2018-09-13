using Pluto.DAL.Entities;
using Pluto.DAL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Pluto.DAL.Services.Implementations
{
    public class TermEntityService : ITermEntityService
    {
        public List<TermEntity> GetTermEntities()
        {
            using (var db = new PlutoContext())
            {
                return db.Terms.Include(t => t.RegisteredSubjectEntities).ToList();
            }
        }

        public int AddTermEntity(TermEntity termEntity)
        {
            using (var db = new PlutoContext())
            {
                db.Terms.Add(termEntity);
                db.SaveChanges();
            }

            return termEntity.Id;
        }

        public void UpdateTermEntity(TermEntity termEntityToUpdate)
        {
            using (var db = new PlutoContext())
            {
                db.Entry(termEntityToUpdate).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteLastTermEntity()
        {
            using (var db = new PlutoContext())
            {
                var term = db.Terms.ToList().LastOrDefault();
                db.Entry(term).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
