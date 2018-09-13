using Pluto.BLL.Model.RegisteredSubjects;
using Pluto.DAL.Entities.RegisteredSubjectEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluto.BLL.Mappers
{
    public static class RegisteredSubjectToRegisteredSubjectEntityMapper
    {
        public static void CreateRegisteredSubjectEntity(this RegisteredSubjectEntity registeredSubjectEntity, RegisteredSubject registeredSubject)
        {
            registeredSubjectEntity.Name = registeredSubject.Name;
            registeredSubjectEntity.Credit = registeredSubject.Credit;
            registeredSubjectEntity.SubjectId = registeredSubject.SubjectId;
            registeredSubjectEntity.TermId = registeredSubject.TermId;
        }
    }
}
