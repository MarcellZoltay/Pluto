using Pluto.BLL.Model.RegisteredSubjects;
using Pluto.DAL;
using Pluto.DAL.Entities.RegisteredSubjectEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Subjects = new List<Subject>();
            Terms = new List<Term>();

            using (var context = new PlutoContext())
            {
                LoadSubjectEntities(context);
                LoadTermEntities(context);
            }
        }
        #endregion

        public List<Subject> Subjects;
        public List<Term> Terms;

        private void LoadSubjectEntities(PlutoContext context)
        {
            var subjects = context.Subjects.ToList();
            foreach (var item in subjects)
            {
                Subjects.Add(new Subject()
                {
                    SubjectId = item.Id,
                    Name = item.Name,
                    Credit = item.Credit,
                    IsRegistered = item.IsRegistered
                });
            }
        }

        private void LoadTermEntities(PlutoContext context)
        {
            var terms = context.Terms.Include(t => t.RegisteredSubjectEntities);

            foreach (var termEntity in terms)
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

                Terms.Add(term);
            }
        }
    }
}
