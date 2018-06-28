using Pluto.BLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluto.BLL.Services
{
    public interface ISubjectService
    {
        List<Subject> GetSubjects();
        Subject GetSubjectById(int? id);
        void AddSubject(Subject subject);
        void UpdateSubject(Subject subjectToUpdate);
        void DeleteSubjectById(int id);
    }
}
