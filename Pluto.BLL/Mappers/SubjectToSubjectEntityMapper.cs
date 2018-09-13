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
        public static SubjectEntity CreateSubjectEntity(this Subject subject)
        {
            var subjectEntity = new SubjectEntity();
            subjectEntity.Name = subject.Name;
            subjectEntity.Credit = subject.Credit;
            // IsRegistered nem kell, mivel csak utolag lehet felvenni

            return subjectEntity;
        }

        public static SubjectEntity UpdateSubjectEntity(this Subject subject)
        {
            var subjectEntity = new SubjectEntity();
            subjectEntity.Id = subject.SubjectId;
            subjectEntity.Name = subject.Name;
            subjectEntity.Credit = subject.Credit;

            return subjectEntity;
        }
    }
}
