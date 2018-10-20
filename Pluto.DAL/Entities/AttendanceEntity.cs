using Pluto.DAL.Entities.RegisteredSubjectEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluto.DAL.Entities
{
    public class AttendanceEntity
    {
        public int Id { get; set; }

        [ForeignKey("RegisteredSubjectEntity")]
        public int RegisteredSubjectId { get; set; }

        public string Name { get; set; }
        public bool IsAttended { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public virtual RegisteredSubjectEntity RegisteredSubjectEntity { get; set; }
    }
}
