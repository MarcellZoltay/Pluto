using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pluto.BLL.DAL;
using Pluto.BLL.Model;

namespace Pluto.BLL.Services
{
    public class TermService : ITermService
    {
        public List<Term> GetTerms(Predicate<Term> predicate = null)
        {
            List<Term> terms;

            using (var db = new PlutoContext())
            {
                if (predicate == null)
                {
                    terms = db.Terms.ToList();
                }
                else
                {
                    terms = db.Terms.ToList();
                    terms = terms.FindAll(predicate);
                }
            }

            return terms;
        }

        public Term GetTermById(int? id)
        {
            Term term;

            using (var db = new PlutoContext())
            {
                term = db.Terms.Find(id);
            }

            return term;
        }

        public void AddTerm(Term term)
        {
            using (var db = new PlutoContext())
            {
                db.Entry(term).State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public void UpdateTerm(Term termToUpdate)
        {
            using (var db = new PlutoContext())
            {
                db.Entry(termToUpdate).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteLastTerm()
        {
            using (var db = new PlutoContext())
            {
                var termList = db.Terms.ToList();
                var term = termList.ElementAt(termList.Count - 1);

                db.Entry(term).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
