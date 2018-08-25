using Pluto.BLL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluto.BLL.Services
{
    public class SubjectRegistrationService : ISubjectRegistrationService
    {
        public void RegisterSubject(Subject subject, Term selectedTerm)
        {
            //TODO: RegisteredSubject class csinalasa, hozzáadása a subject és a selectedTerm-hez is
            subject.IsRegistered = true;

            //using (var db = new PlutoContext())
            //{
            //    db.Entry(subject).State = EntityState.Modified;
            //    db.SaveChanges();
            //}
        }
    }
}
