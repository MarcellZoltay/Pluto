using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pluto.BLL.Mappers;
using Pluto.BLL.Model;
using Pluto.DAL;
using Pluto.DAL.Entities.SubjectEntities;

namespace Pluto.BLL.Services
{
    public class SubjectService : ISubjectService
    {
        public async Task<List<Subject>> GetSubjects()
        {
            return await Task.Factory.StartNew<List<Subject>>(() => Model.Model.Instance.Subjects);
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

        public async void AddSubject(Subject subject)
        {
            await Task.Factory.StartNew(() =>
            {
                using (var db = new PlutoContext())
                {
                    SubjectEntity subjectEntity = new SubjectEntity();

                    subjectEntity.CreateSubjectEntity(subject);

                    db.Subjects.Add(subjectEntity);
                    db.SaveChanges();

                    subject.SubjectId = subjectEntity.Id;
                }
            });
        }

        public async void UpdateSubject(Subject subjectToUpdate)
        {
            await Task.Factory.StartNew(() =>
            {
                using (var db = new PlutoContext())
                {
                    SubjectEntity subjectEntity = db.Subjects.FirstOrDefault(e => e.Id == subjectToUpdate.SubjectId);

                    subjectEntity.UpdateSubjectEntity(subjectToUpdate);

                    db.Entry(subjectEntity).State = EntityState.Modified;
                    db.SaveChanges();
                }
            });
        }

        public async void DeleteSubjectById(int id)
        {
            await Task.Factory.StartNew(() =>
            {
                using (var db = new PlutoContext())
                {
                    var subject = db.Subjects.FirstOrDefault(e => e.Id == id);
                    db.Entry(subject).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            });
        }
    }
}
