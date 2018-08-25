using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluto.DAL.Entities.SubjectEntities
{
    public class SubjectEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Credit { get; set; }
        public bool IsRegistered { get; set; }
    }
}
