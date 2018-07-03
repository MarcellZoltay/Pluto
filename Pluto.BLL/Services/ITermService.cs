using Pluto.BLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluto.BLL.Services
{
    public interface ITermService
    {
        List<Term> GetTerms(Predicate<Term> predicate = null);
        Term GetTermById(int? id);
        void AddTerm(Term term);
        void UpdateTerm(Term term);
        void DeleteLastTerm();
    }
}
