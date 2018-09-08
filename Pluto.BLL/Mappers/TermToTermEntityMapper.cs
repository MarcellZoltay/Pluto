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
        public static void CreateTermEntity(this TermEntity termEntity, Term term)
        {
            termEntity.Name = term.Name;
            termEntity.IsActive = term.IsActive;
        }

        public static void UpdateTermEntity(this TermEntity termEntity, Term term)
        {
            termEntity.IsActive = term.IsActive;
        }
    }
}
