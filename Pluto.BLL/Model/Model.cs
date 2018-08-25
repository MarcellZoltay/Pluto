using Pluto.DAL;
using System;
using System.Collections.Generic;
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
                MapSubjectEntities(context);
                MapTermEntities(context);
            }
        }
        #endregion

        public List<Subject> Subjects;
        public List<Term> Terms;

        private void MapSubjectEntities(PlutoContext context)
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

        private void MapTermEntities(PlutoContext context)
        {
            var terms = context.Terms.ToList();
            foreach (var item in terms)
            {
                Terms.Add(new Term()
                {
                    TermId = item.Id,
                    Name = item.Name,
                    IsActive = item.IsActive
                });
            }
        }
    }
}
