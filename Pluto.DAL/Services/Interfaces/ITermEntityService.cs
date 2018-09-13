using Pluto.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluto.DAL.Services.Interfaces
{
    public interface ITermEntityService
    {
        List<TermEntity> GetTermEntities();
        int AddTermEntity(TermEntity termEntity);
        void UpdateTermEntity(TermEntity termEntityToUpdate);
        void DeleteLastTermEntity();
    }
}
