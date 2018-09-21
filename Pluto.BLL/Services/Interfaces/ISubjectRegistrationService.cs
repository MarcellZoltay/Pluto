using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pluto.BLL.Model;

namespace Pluto.BLL.Services
{
    public interface ISubjectRegistrationService
    {
        Task RegisterSubjectAsync(Subject subject, Term selectedTerm);
        Task<bool> UnregisterSubjectAsync(Subject subject);
    }
}
