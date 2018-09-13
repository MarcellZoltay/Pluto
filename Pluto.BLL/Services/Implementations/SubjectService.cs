using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pluto.BLL.Model;

namespace Pluto.BLL.Services
{
    public class SubjectService : ISubjectService
    {
        public async Task<List<Subject>> GetSubjects()
        {
            return await Task.Factory.StartNew<List<Subject>>(() => Model.Model.Instance.GetSubjects());
        }

        public Subject GetSubjectById(int? id)
        {
            //Subject subject = null;

            //using (var db = new PlutoContext())
            //{
            //    subject = db.Subjects.Find(id);
            //}

            //return Model.Model.Instance.Subjects.Find(s => s.SubjectId == id);
            return null;
        }

        public async void AddSubject(Subject subject)
        {
            await Task.Factory.StartNew(() => Model.Model.Instance.AddSubject(subject));
        }

        public async void UpdateSubject(Subject subjectToUpdate)
        {
            await Task.Factory.StartNew(() => Model.Model.Instance.UpdateSubject(subjectToUpdate));
        }

        public async void DeleteSubjectById(int subjectId)
        {
            await Task.Factory.StartNew(() => Model.Model.Instance.DeleteSubjectById(subjectId));
        }
    }
}
