using Pluto.BLL.Mappers;
using Pluto.BLL.Model.RegisteredSubjects;
using Pluto.DAL;
using Pluto.DAL.Entities.RegisteredSubjectEntities;
using Pluto.DAL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Pluto.BLL.Model
{
    public class Model
    {
        #region Singleton
        private static Model instance = new Model();
        public static Model Instance
        {
            get { return instance; }
        }

        private Model()
        {
            subjectEntityService = UnityBootstrapper.UnityBootstrapperInstance.Container.Resolve<ISubjectEntityService>();
            termEntityService = UnityBootstrapper.UnityBootstrapperInstance.Container.Resolve<ITermEntityService>();

            subjects = new List<Subject>();
            terms = new List<Term>();

            LoadSubjectEntities();
            LoadTermEntities();
        }
        #endregion

        private ISubjectEntityService subjectEntityService;
        private ITermEntityService termEntityService;

        private List<Subject> subjects;
        private List<Term> terms;

        private void LoadSubjectEntities()
        {
            var subjectEntities = subjectEntityService.GetSubjectEntities();
            foreach (var item in subjectEntities)
            {
                subjects.Add(new Subject()
                {
                    SubjectId = item.Id,
                    Name = item.Name,
                    Credit = item.Credit,
                    IsRegistered = item.IsRegistered
                });
            }
        }
        private void LoadTermEntities()
        {
            var termEntities = termEntityService.GetTermEntities();

            foreach (var termEntity in termEntities)
            {
                List<RegisteredSubject> registeredSubjects = new List<RegisteredSubject>();

                foreach (var registeredSubjectEntity in termEntity.RegisteredSubjectEntities)
                {
                    var registeredSubject = new RegisteredSubject()
                    {
                        RegisteredSubjectId = registeredSubjectEntity.Id,
                        Name = registeredSubjectEntity.Name,
                        Credit = registeredSubjectEntity.Credit,
                        SubjectId = registeredSubjectEntity.SubjectId,
                        TermId = registeredSubjectEntity.TermId
                    };

                    registeredSubjects.Add(registeredSubject);
                }

                var term = new Term(registeredSubjects)
                {
                    TermId = termEntity.Id,
                    Name = termEntity.Name,
                    IsActive = termEntity.IsActive
                };

                terms.Add(term);
            }
        }

        
        public List<Term> GetTerms(Predicate<Term> predicate)
        {
            return predicate == null ? terms : terms.FindAll(predicate);
        }
        public void AddTerm(Term term)
        {
            var entity = term.CreateTermEntity();
            term.TermId = termEntityService.AddTermEntity(entity);

            terms.Add(term);
        }
        public void UpdateTerm(Term termToUpdate)
        {
            var entity = termToUpdate.UpdateTermEntity();
            termEntityService.UpdateTermEntity(entity);
        }
        public void DeleteLastTerm()
        {
            termEntityService.DeleteLastTermEntity();

            terms.RemoveAt(terms.Count - 1);
        }


        public List<Subject> GetSubjects()
        {
            return subjects;
        }
        public void AddSubject(Subject subject)
        {
            var entity = subject.CreateSubjectEntity();
            subject.SubjectId = subjectEntityService.AddSubjectEntity(entity);

            subjects.Add(subject);
        }
        public void UpdateSubject(Subject subjectToUpdate)
        {
            var entity = subjectToUpdate.UpdateSubjectEntity();
            subjectEntityService.UpdateSubjectEntity(entity);
        }
        public void DeleteSubjectById(int subjectId)
        {
            subjectEntityService.DeleteSubjectEntityById(subjectId);

            subjects.Remove(subjects.Find(s => s.SubjectId == subjectId));
        }
    }
}
