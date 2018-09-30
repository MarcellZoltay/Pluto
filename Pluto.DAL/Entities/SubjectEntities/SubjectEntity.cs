using Pluto.DAL.Entities.RegisteredSubjectEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluto.DAL.Entities.SubjectEntities
{
    public class SubjectEntity
    {
        public SubjectEntity()
        {
            RegisteredSubjectEntities = new HashSet<RegisteredSubjectEntity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Credit { get; set; }
        public bool IsRegistered { get; set; }
        public int ActualRegisteredSubjectId { get; set; }
        public bool IsCompleted { get; set; }

        public virtual ICollection<RegisteredSubjectEntity> RegisteredSubjectEntities { get; set; }
    }
}
