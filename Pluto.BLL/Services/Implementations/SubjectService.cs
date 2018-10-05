using Pluto.BLL.Model.Subjects;
using Pluto.BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluto.BLL.Services.Implementations
{
    public class SubjectService : ISubjectService
    {
        public async Task<List<Subject>> GetSubjectsAsync()
        {
            return await Task.Factory.StartNew<List<Subject>>(() => Model.DataManager.Instance.GetSubjects());
        }
        public async Task AddSubjectAsync(Subject subject)
        {
            await Task.Factory.StartNew(() => Model.DataManager.Instance.AddSubject(subject));
        }
        public async Task UpdateSubjectAsync(Subject subjectToUpdate)
        {
            await Task.Factory.StartNew(() => Model.DataManager.Instance.UpdateSubject(subjectToUpdate));
        }
        public async Task<bool> DeleteSubjectAsync(Subject subjectToDelete)
        {
            if (subjectToDelete.IsDeletable)
            {
                await Task.Factory.StartNew(() => Model.DataManager.Instance.DeleteSubject(subjectToDelete));
                return true;
            }

            return false;
        }
    }
}
