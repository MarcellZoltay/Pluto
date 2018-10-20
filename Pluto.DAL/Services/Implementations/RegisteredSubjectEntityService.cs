using Pluto.DAL.Entities.RegisteredSubjectEntities;
using Pluto.DAL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluto.DAL.Services.Implementations
{
    public class RegisteredSubjectEntityService : IRegisteredSubjectEntityService
    {
        public List<RegisteredSubjectEntity> GetRegisteredSubjectEntities()
        {
            using (var db = new PlutoContext())
            {
                return db.RegisteredSubjects.Include("AttendanceEntities").ToList();
            }
        }

        public int AddRegisteredSubjectEntity(RegisteredSubjectEntity registeredSubjectEntity)
        {
            using (var db = new PlutoContext())
            {
                db.RegisteredSubjects.Add(registeredSubjectEntity);
                db.SaveChanges();
            }

            return registeredSubjectEntity.Id;
        }

        public void UpdateRegisteredSubjectEntity(RegisteredSubjectEntity registeredSubjectEntityToUpdate)
        {
            using (var db = new PlutoContext())
            {
                db.Entry(registeredSubjectEntityToUpdate).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteRegisteredSubjectEntity(RegisteredSubjectEntity registeredSubjectEntityToDelete)
        {
            using (var db = new PlutoContext())
            {
                db.Entry(registeredSubjectEntityToDelete).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
