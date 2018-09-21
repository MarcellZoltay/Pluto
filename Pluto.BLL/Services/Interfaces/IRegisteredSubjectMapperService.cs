using Pluto.BLL.Model.RegisteredSubjects;
using Pluto.DAL.Entities.RegisteredSubjectEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluto.BLL.Services.Interfaces
{
    public interface IRegisteredSubjectMapperService
    {
        List<RegisteredSubject> GetRegisteredSubjects();
        void AddRegisteredSubject(RegisteredSubject registeredSubject);
        void UpdateRegisteredSubject(RegisteredSubject registeredSubjectToUpdate);
        void DeleteRegisteredSubject(RegisteredSubject registeredSubjectToDelete);
    }
}
