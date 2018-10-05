using Pluto.BLL.Model;
using Pluto.BLL.Model.Subjects;
using Pluto.BLL.Services.Interfaces;
using Pluto.DAL.Entities.SubjectEntities;
using Pluto.DAL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Pluto.BLL.Services.Implementations
{
    class SubjectMapperService : ISubjectMapperService
    {
        private ISubjectEntityService subjectEntityService;

        public SubjectMapperService()
        {
            subjectEntityService = UnityBootstrapper.UnityBootstrapperInstance.Resolve<ISubjectEntityService>();
        }

        public List<Subject> GetSubjects()
        {
            List<Subject> subjects = new List<Subject>();
            var subjectEntities = subjectEntityService.GetSubjectEntities();

            foreach (var item in subjectEntities)
            {
                var subject = ConvertToModel(item);
                subjects.Add(subject);
            }
            
            return subjects;
        }
        public void AddSubject(Subject subject)
        {
            var subjectEntity = ConvertToEntity(subject);
            subject.SubjectId = subjectEntityService.AddSubjectEntity(subjectEntity);
        }
        public void UpdateSubject(Subject subjectToUpdate)
        {
            var subjectEntity = ConvertToEntity(subjectToUpdate);
            subjectEntityService.UpdateSubjectEntity(subjectEntity);
        }
        public void DeleteSubject(Subject subjectToDelete)
        {
            var subjectEntity = ConvertToEntity(subjectToDelete);
            subjectEntityService.DeleteSubjectEntity(subjectEntity);
        }

        private SubjectEntity ConvertToEntity(Subject subject)
        {
            return new SubjectEntity()
            {
                Id = subject.SubjectId,
                Name = subject.Name,
                Credit = subject.Credit,
                IsRegistered = subject.IsRegistered,
                ActualRegisteredSubjectId = subject.ActualRegisteredSubject == null ? 0 : subject.ActualRegisteredSubject.RegisteredSubjectId,
                IsCompleted = subject.IsCompleted
            };
        }

        private Subject ConvertToModel(SubjectEntity subjectEntity)
        {
            var subject = new Subject(subjectEntity.Name, subjectEntity.Credit);
            subject.Load(subjectEntity.Id, subjectEntity.IsRegistered, subjectEntity.IsCompleted, subjectEntity.ActualRegisteredSubjectId);

            return subject;
        }
    }
}
