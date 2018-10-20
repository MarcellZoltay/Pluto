using Pluto.BLL.Model;
using Pluto.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluto.BLL.Services.Interfaces
{
    public interface IAttendanceMapperService
    {
        Attendance GetAttendance(AttendanceEntity attendanceEntity);
        void AddAttendance(Attendance attendance);
        void UpdateAttendance(Attendance attendanceToUpdate);
        void DeleteAttendance(Attendance attendanceToDelete);
    }
}
