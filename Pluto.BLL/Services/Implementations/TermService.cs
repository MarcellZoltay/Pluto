using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pluto.BLL.Mappers;
using Pluto.BLL.Model;
using Pluto.DAL;
using Pluto.DAL.Entities;

namespace Pluto.BLL.Services
{
    public class TermService : ITermService
    {
        public async Task<List<Term>> GetTerms(Predicate<Term> predicate = null)
        {
            return await Task.Factory.StartNew<List<Term>>(() => 
                predicate == null ? Model.Model.Instance.Terms : Model.Model.Instance.Terms.FindAll(predicate)
            );
        }

        public Term GetTermById(int? id)
        {
            Term term = null;

            //using (var db = new PlutoContext())
            //{
            //    term = db.Terms.Find(id);
            //}

            return term;
        }

        public async void AddTerm(Term term)
        {
            await Task.Factory.StartNew(() =>
            {
                Model.Model.Instance.Terms.Add(term);

                using (var db = new PlutoContext())
                {
                    TermEntity termEntity = new TermEntity();

                    termEntity.CreateTermEntity(term);

                    db.Terms.Add(termEntity);
                    db.SaveChanges();

                    term.TermId = termEntity.Id;
                }
            });
        }

        public async void UpdateTerm(Term termToUpdate)
        {
            await Task.Factory.StartNew(() =>
            {
                var term = Model.Model.Instance.Terms.Find(t => t.TermId == termToUpdate.TermId);
                term.IsActive = termToUpdate.IsActive;

                using (var db = new PlutoContext())
                {
                    TermEntity termEntity = db.Terms.FirstOrDefault(e => e.Id == termToUpdate.TermId);

                    termEntity.UpdateTermEntity(termToUpdate);

                    db.Entry(termEntity).State = EntityState.Modified;
                    db.SaveChanges();
                }
            });
        }

        public async void DeleteLastTerm()
        {
            await Task.Factory.StartNew(() =>
            {
                Model.Model.Instance.Terms.RemoveAt(Model.Model.Instance.Terms.Count - 1);

                using (var db = new PlutoContext())
                {
                    var term = db.Terms.ToList().LastOrDefault();
                    db.Entry(term).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            });
        }
    }
}
