using Pluto.BLL.Model;
using Pluto.BLL.Model.RegisteredSubjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluto.BLL.Services.Interfaces
{
    public interface IRegisteredSubjectService
    {
        event EventHandler RegisteredSubjectsChanged;

        Task<List<RegisteredSubject>> GetRegisteredSubjectsAsync();

        Task RegisterSubjectAsync(Subject subject, Term selectedTerm);
        Task<bool> UnregisterSubjectAsync(Subject subject);
    }
}
