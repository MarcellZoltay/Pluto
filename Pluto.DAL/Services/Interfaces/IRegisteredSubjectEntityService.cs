using Pluto.DAL.Entities.RegisteredSubjectEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluto.DAL.Services.Interfaces
{
    public interface IRegisteredSubjectEntityService
    {
        List<RegisteredSubjectEntity> GetRegisteredSubjectEntities();
        int AddRegisteredSubjectEntity(RegisteredSubjectEntity registeredSubjectEntity);
        void UpdateRegisteredSubjectEntity(RegisteredSubjectEntity registeredSubjectEntityToUpdate);
        void DeleteRegisteredSubjectEntity(RegisteredSubjectEntity registeredSubjectEntityToDelete);
    }
}
