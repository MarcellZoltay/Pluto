using Pluto.DAL.Entities.RegisteredSubjectEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluto.DAL.Entities
{
    public class TermEntity
    {
        public TermEntity()
        {
            RegisteredSubjectEntities = new HashSet<RegisteredSubjectEntity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<RegisteredSubjectEntity> RegisteredSubjectEntities { get; set; }
    }
}
