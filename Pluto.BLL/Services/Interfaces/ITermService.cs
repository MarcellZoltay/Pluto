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
        Task<List<Term>> GetTermsAsync(Predicate<Term> predicate = null);
        Term GetTermById(int? id);
        Task AddTermAsync(Term term);
        Task UpdateTermAsync(Term termToUpdate);
        Task<bool> DeleteLastTermAsync();
        Task CloseTermAsync(Term termToClose);
    }
}
