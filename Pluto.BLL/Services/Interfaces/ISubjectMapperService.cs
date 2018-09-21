using Pluto.BLL.Model;
using Pluto.DAL.Entities.SubjectEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluto.BLL.Services.Interfaces
{
    interface ISubjectMapperService
    {
        List<Subject> GetSubjects();
        void AddSubject(Subject subject);
        void UpdateSubject(Subject subjectToUpdate);
        void DeleteSubject(Subject subjectToDelete);
    }
}
