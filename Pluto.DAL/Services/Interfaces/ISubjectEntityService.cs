using Pluto.DAL.Entities.SubjectEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluto.DAL.Services.Interfaces
{
    public interface ISubjectEntityService
    {
        List<SubjectEntity> GetSubjectEntities();
        int AddSubjectEntity(SubjectEntity subjectEntity);
        void UpdateSubjectEntity(SubjectEntity subjectEntityToUpdate);
        void DeleteSubjectEntityById(int subjectEntityId);
    }
}
