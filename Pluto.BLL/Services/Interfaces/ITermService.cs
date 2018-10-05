using Pluto.BLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluto.BLL.Services.Interfaces
{
    public interface ITermService
    {
        event EventHandler TermsChanged;

        Task<List<Term>> GetTermsAsync(Predicate<Term> predicate = null);
        Task AddTermAsync(Term term);
        Task UpdateTermAsync(Term termToUpdate);
        Task<bool> DeleteLastTermAsync();
        Task<bool> CloseTermAsync(Term termToClose);
    }
}
