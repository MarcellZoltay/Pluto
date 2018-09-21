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
        Task<List<Subject>> GetSubjectsAsync();
        Subject GetSubjectById(int? id);
        Task AddSubjectAsync(Subject subject);
        Task UpdateSubjectAsync(Subject subjectToUpdate);
        Task<bool> DeleteSubjectAsync(Subject subjectToDelete);
    }
}
