using Pluto.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluto.DAL.Services.Interfaces
{
    public interface IAttendanceEntityService
    {
        int AddAttendanceEntity(AttendanceEntity attendanceEntity);
        void UpdateAttendanceEntity(AttendanceEntity attendanceEntityToUpdate);
        void DeleteAttendanceEntity(AttendanceEntity attendanceEntityToDelete);
    }
}
