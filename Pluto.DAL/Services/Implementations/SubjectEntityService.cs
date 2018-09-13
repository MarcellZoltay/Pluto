using Pluto.DAL.Entities.SubjectEntities;
using Pluto.DAL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluto.DAL.Services.Implementations
{
    public class SubjectEntityService : ISubjectEntityService
    {
        public List<SubjectEntity> GetSubjectEntities()
        {
            using (var db = new PlutoContext())
            {
                return db.Subjects.ToList();
            }
        }

        public int AddSubjectEntity(SubjectEntity subjectEntity)
        {
            using (var db = new PlutoContext())
            {
                db.Subjects.Add(subjectEntity);
                db.SaveChanges();
            }

            return subjectEntity.Id;
        }

        public void UpdateSubjectEntity(SubjectEntity subjectEntityToUpdate)
        {
            using (var db = new PlutoContext())
            {
                db.Entry(subjectEntityToUpdate).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteSubjectEntityById(int subjectEntityId)
        {
            using (var db = new PlutoContext())
            {
                var subject = db.Subjects.FirstOrDefault(e => e.Id == subjectEntityId);
                db.Entry(subject).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

    }
}
