using Pluto.BLL.Model.RegisteredSubjects;
using Pluto.BLL.Services.Interfaces;
using Pluto.DAL.Entities.RegisteredSubjectEntities;
using Pluto.DAL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Pluto.BLL.Services.Implementations
{
    class RegisteredSubjectMapperService : IRegisteredSubjectMapperService
    {
        private IRegisteredSubjectEntityService registeredSubjectEntityService;

        public RegisteredSubjectMapperService()
        {
            registeredSubjectEntityService = UnityBootstrapper.UnityBootstrapperInstance.Container.Resolve<IRegisteredSubjectEntityService>();
        }

        public List<RegisteredSubject> GetRegisteredSubjects()
        {
            List<RegisteredSubject> registeredSubjects = new List<RegisteredSubject>();
            var registeredSubjectEntities = registeredSubjectEntityService.GetRegisteredSubjectEntities();

            foreach (var item in registeredSubjectEntities)
            {
                var subject = ConvertToModel(item);
                registeredSubjects.Add(subject);
            }

            return registeredSubjects;
        }

        public void AddRegisteredSubject(RegisteredSubject registeredSubject)
        {
            var subjectEntity = ConvertToEntity(registeredSubject);
            registeredSubject.RegisteredSubjectId = registeredSubjectEntityService.AddRegisteredSubjectEntity(subjectEntity);
        }

        public void UpdateRegisteredSubject(RegisteredSubject registeredSubjectToUpdate)
        {
            var subjectEntity = ConvertToEntity(registeredSubjectToUpdate);
            registeredSubjectEntityService.UpdateRegisteredSubjectEntity(subjectEntity);
        }

        public void DeleteRegisteredSubject(RegisteredSubject registeredSubjectToDelete)
        {
            var subjectEntity = ConvertToEntity(registeredSubjectToDelete);
            registeredSubjectEntityService.DeleteRegisteredSubjectEntity(subjectEntity);
        }

        private RegisteredSubjectEntity ConvertToEntity(RegisteredSubject registeredSubject)
        {
            return new RegisteredSubjectEntity()
            {
                Id = registeredSubject.RegisteredSubjectId,
                SubjectId = registeredSubject.SubjectId,
                TermId = registeredSubject.TermId,
                Name = registeredSubject.Name,
                Credit = registeredSubject.Credit,
                IsClosed = registeredSubject.IsClosed
            };
        }

        private RegisteredSubject ConvertToModel(RegisteredSubjectEntity registeredSubjectEntity)
        {
            var registereSubject = new RegisteredSubject()
            {
                RegisteredSubjectId = registeredSubjectEntity.Id,
                Name = registeredSubjectEntity.Name,
                Credit = registeredSubjectEntity.Credit
            };
            registereSubject.Load(registeredSubjectEntity.SubjectId, registeredSubjectEntity.TermId, registeredSubjectEntity.IsClosed);
            return registereSubject;
        }
    }
}
