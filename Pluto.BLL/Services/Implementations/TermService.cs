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
            return await Task.Factory.StartNew<List<Term>>(() => Model.Model.Instance.GetTerms(predicate));
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
            await Task.Factory.StartNew(() => Model.Model.Instance.AddTerm(term));
        }

        public async void UpdateTerm(Term termToUpdate)
        {
            await Task.Factory.StartNew(() => Model.Model.Instance.UpdateTerm(termToUpdate));
        }

        public async void DeleteLastTerm()
        {
            await Task.Factory.StartNew(() => Model.Model.Instance.DeleteLastTerm());
        }
    }
}
