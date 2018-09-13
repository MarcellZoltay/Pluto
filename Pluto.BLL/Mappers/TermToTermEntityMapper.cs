using Pluto.BLL.Model;
using Pluto.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluto.BLL.Mappers
{
    public static class TermToTermEntityMapper
    {
        public static TermEntity CreateTermEntity(this Term term)
        {
            var termEntity = new TermEntity();
            termEntity.Name = term.Name;
            termEntity.IsActive = term.IsActive;

            return termEntity;
        }

        public static TermEntity UpdateTermEntity(this Term term)
        {
            var termEntity = new TermEntity();
            termEntity.Id = term.TermId;
            termEntity.Name = term.Name;
            termEntity.IsActive = term.IsActive;

            return termEntity;
        }
    }
}
