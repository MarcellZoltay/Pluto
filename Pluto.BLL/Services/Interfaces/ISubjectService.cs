using Pluto.BLL.Model;
using Pluto.BLL.Model.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluto.BLL.Services.Interfaces
{
    public interface ISubjectService
    {
        Task<List<Subject>> GetSubjectsAsync();
        Task AddSubjectAsync(Subject subject);
        Task UpdateSubjectAsync(Subject subjectToUpdate);
        Task<bool> DeleteSubjectAsync(Subject subjectToDelete);
    }
}
