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
        void RegisterSubject(Subject subject, Term selectedTerm);
    }
}
