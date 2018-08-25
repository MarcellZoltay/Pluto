using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pluto.BLL.Model;

namespace Pluto.BLL.Services
{
    public class SubjectService : ISubjectService
    {
        public List<Subject> GetSubjects()
        {
            return Model.Model.Instance.Subjects;
        }

        public Subject GetSubjectById(int? id)
        {
            //Subject subject = null;

            //using (var db = new PlutoContext())
            //{
            //    subject = db.Subjects.Find(id);
            //}

            return Model.Model.Instance.Subjects.Find(s => s.SubjectId == id);
        }

        public void AddSubject(Subject subject)
        {
            //using (var db = new PlutoContext())
            //{
            //    db.Entry(subject).State = EntityState.Added;
            //    db.SaveChanges();
            //}
        }

        public void UpdateSubject(Subject subjectToUpdate)
        {
            //using (var db = new PlutoContext())
            //{
            //    db.Entry(subjectToUpdate).State = EntityState.Modified;
            //    db.SaveChanges();
            //}
        }

        public void DeleteSubjectById(int id)
        {
            //using (var db = new PlutoContext())
            //{
            //    var subject = db.Subjects.Find(id);

            //    db.Entry(subject).State = EntityState.Deleted;
            //    db.SaveChanges();
            //}
        }
    }
}
