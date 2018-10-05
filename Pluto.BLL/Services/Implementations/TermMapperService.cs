using Pluto.BLL.Model;
using Pluto.BLL.Services.Interfaces;
using Pluto.DAL.Entities;
using Pluto.DAL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Pluto.BLL.Services.Implementations
{
    class TermMapperService : ITermMapperService
    {
        private ITermEntityService termEntityService;

        public TermMapperService()
        {
            termEntityService = UnityBootstrapper.UnityBootstrapperInstance.Resolve<ITermEntityService>();
        }

        public List<Term> GetTerms()
        {
            List<Term> terms = new List<Term>();
            var termEntities = termEntityService.GetTermEntities();

            foreach (var item in termEntities)
            {
                var term = ConvertToModel(item);
                terms.Add(term);
            }

            return terms;
        }
        public void AddTerm(Term term)
        {
            var termEntity = ConvertToEntity(term);
            term.TermId = termEntityService.AddTermEntity(termEntity);
        }
        public void UpdateTerm(Term termToUpdate)
        {
            var termEntity = ConvertToEntity(termToUpdate);
            termEntityService.UpdateTermEntity(termEntity);
        }
        public void DeleteTerm(Term termToDelete)
        {
            var termEntity = ConvertToEntity(termToDelete);
            termEntityService.DeleteTermEntity(termEntity);
        }

        private TermEntity ConvertToEntity(Term term)
        {
            return new TermEntity()
            {
                Id = term.TermId,
                Name = term.Name,
                IsActive = term.IsActive,
                IsClosed = term.IsClosed
            };
        }

        private Term ConvertToModel(TermEntity termEntity)
        {
            var term = new Term(termEntity.Name, termEntity.IsActive);
            term.Load(termEntity.Id, termEntity.IsClosed);

            return term;
        }
    }
}
