using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pluto.BLL.Model;

namespace Pluto.BLL.Services
{
    public class TermService : ITermService
    {
        public async Task<List<Term>> GetTermsAsync(Predicate<Term> predicate = null)
        {
            return await Task.Factory.StartNew<List<Term>>(() => Model.DataManager.Instance.GetTerms(predicate));
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

        public async Task AddTermAsync(Term term)
        {
            await Task.Factory.StartNew(() => Model.DataManager.Instance.AddTerm(term));
        }

        public async Task UpdateTermAsync(Term termToUpdate)
        {
            await Task.Factory.StartNew(() => Model.DataManager.Instance.UpdateTerm(termToUpdate));
        }

        public async Task<bool> DeleteLastTermAsync()
        {
            var terms = Model.DataManager.Instance.GetTerms(null);
            var term = terms.ElementAt(terms.Count - 1);

            if (term.IsDeletable)
            {
                await Task.Factory.StartNew(() => Model.DataManager.Instance.DeleteTerm(term));
                return true;
            }

            return false;
        }

        public async Task<bool> CloseTermAsync(Term termToClose)
        {
            if (termToClose.IsActive && !termToClose.IsClosed)
            {
                termToClose.Close();
                await Task.Factory.StartNew(() => Model.DataManager.Instance.CloseTerm(termToClose));

                return true;
            }

            return false;
        }
    }
}
