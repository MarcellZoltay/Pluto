using Pluto.BLL.Model;
using Pluto.DAL.Entities.SubjectEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluto.BLL.Mappers
{
    public static class SubjectToSubjectEntityMapper
    {
        public static void CreateSubjectEntity(this SubjectEntity subjectEntity, Subject subject)
        {
            subjectEntity.Name = subject.Name;
            subjectEntity.Credit = subject.Credit;
            // IsRegistered nem kell, mivel csak utolag lehet felvenni
        }

        public static void UpdateSubjectEntity(this SubjectEntity subjectEntity, Subject subject)
        {
            subjectEntity.Name = subject.Name;
            subjectEntity.Credit = subject.Credit;
        }
    }
}
