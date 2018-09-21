using Pluto.BLL.Model;
using Pluto.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluto.BLL.Services.Interfaces
{
    interface ITermMapperService
    {
        List<Term> GetTerms();
        void AddTerm(Term term);
        void UpdateTerm(Term termToUpdate);
        void DeleteTerm(Term termToDelete);
    }
}
