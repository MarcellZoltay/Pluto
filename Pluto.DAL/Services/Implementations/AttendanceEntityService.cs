using Pluto.DAL.Entities;
using Pluto.DAL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluto.DAL.Services.Implementations
{
    public class AttendanceEntityService : IAttendanceEntityService
    {
        public int AddAttendanceEntity(AttendanceEntity attendanceEntity)
        {
            using (var db = new PlutoContext())
            {
                db.Attendances.Add(attendanceEntity);
                db.SaveChanges();
            }

            return attendanceEntity.Id;
        }

        public void UpdateAttendanceEntity(AttendanceEntity attendanceEntityToUpdate)
        {
            using (var db = new PlutoContext())
            {
                db.Entry(attendanceEntityToUpdate).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteAttendanceEntity(AttendanceEntity attendanceEntityToDelete)
        {
            using (var db = new PlutoContext())
            {
                db.Entry(attendanceEntityToDelete).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
