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
                return db.Terms.ToList();
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

        public void DeleteTermEntity(TermEntity termEntityToDelete)
        {
            using (var db = new PlutoContext())
            {
                db.Entry(termEntityToDelete).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
