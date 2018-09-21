using Pluto.DAL.Entities.SubjectEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluto.DAL.Entities.RegisteredSubjectEntities
{
    public class RegisteredSubjectEntity
    {
        public int Id { get; set; }

        [ForeignKey("SubjectEntity")]
        public int SubjectId { get; set; }
        [ForeignKey("TermEntity")]
        public int TermId { get; set; }

        public string Name { get; set; }
        public int Credit { get; set; }
        public bool IsClosed { get; set; }

        public virtual SubjectEntity SubjectEntity { get; set; }
        public virtual TermEntity TermEntity { get; set; }
    }
}
