using Pluto.BLL.Mappers;
using Pluto.BLL.Model;
using Pluto.BLL.Model.RegisteredSubjects;
using Pluto.DAL;
using Pluto.DAL.Entities.RegisteredSubjectEntities;
using Pluto.DAL.Entities.SubjectEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluto.BLL.Services
{
    public class SubjectRegistrationService : ISubjectRegistrationService
    {
        public async void RegisterSubject(Subject subject, Term selectedTerm)
        {
            var registeredSubject = new RegisteredSubject();

            subject.SetRegisteredSubject(registeredSubject);

            var result = selectedTerm.RegisterSubject(registeredSubject);

            if (result)
            {
                subject.Register(registeredSubject);
                subject.IsRegistered = true;

                await Task.Factory.StartNew(() =>
                {
                    using (var db = new PlutoContext())
                    {
                        var registeredSubjectEntity = new RegisteredSubjectEntity();
                        registeredSubjectEntity.CreateRegisteredSubjectEntity(registeredSubject);

                        db.RegisteredSubjects.Add(registeredSubjectEntity);

                        SubjectEntity subjectEntity = db.Subjects.FirstOrDefault(e => e.Id == subject.SubjectId);
                        subjectEntity.IsRegistered = subject.IsRegistered;
                        db.Entry(subjectEntity).State = EntityState.Modified;

                        db.SaveChanges();

                        registeredSubject.RegisteredSubjectId = registeredSubjectEntity.Id;
                    }
                });
            }
        }

        public async void UnregisterSubject(Subject subject)
        {
            //var registeredSubject = subject.R

            //if (result)
            //{
            //    subject.SetRegisteredSubject(registeredSubject);
            //    subject.IsRegistered = true;

            //    await Task.Factory.StartNew(() =>
            //    {
            //        using (var db = new PlutoContext())
            //        {
            //            var registeredSubjectEntity = new RegisteredSubjectEntity();
            //            registeredSubjectEntity.CreateRegisteredSubjectEntity(registeredSubject);

            //            registeredSubjectEntity.SubjectId = subject.SubjectId;
            //            registeredSubjectEntity.TermId = selectedTerm.TermId;

            //            db.RegisteredSubjects.Add(registeredSubjectEntity);

            //            SubjectEntity subjectEntity = db.Subjects.FirstOrDefault(e => e.Id == subject.SubjectId);
            //            subjectEntity.IsRegistered = subject.IsRegistered;
            //            db.Entry(subjectEntity).State = EntityState.Modified;

            //            db.SaveChanges();

            //            registeredSubject.RegisteredSubjectId = registeredSubjectEntity.Id;
            //        }
            //    });
            //}
        }
    }
}
