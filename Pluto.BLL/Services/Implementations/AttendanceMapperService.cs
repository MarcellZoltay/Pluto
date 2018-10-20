using Pluto.BLL.Model;
using Pluto.BLL.Services.Interfaces;
using Pluto.DAL.Entities;
using Pluto.DAL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluto.BLL.Services.Implementations
{
    public class AttendanceMapperService : IAttendanceMapperService
    {
        private IAttendanceEntityService attendanceEntityService;

        public AttendanceMapperService()
        {
            attendanceEntityService = UnityBootstrapper.UnityBootstrapperInstance.Resolve<IAttendanceEntityService>();
        }

        public Attendance GetAttendance(AttendanceEntity attendanceEntity)
        {
            var attendance = ConvertToModel(attendanceEntity);
            return attendance;
        }
        public void AddAttendance(Attendance attendance)
        {
            var attendanceEntity = ConvertToEntity(attendance);
            attendance.AttendanceId = attendanceEntityService.AddAttendanceEntity(attendanceEntity);
        }
        public void UpdateAttendance(Attendance attendanceToUpdate)
        {
            var attendanceEntity = ConvertToEntity(attendanceToUpdate);
            attendanceEntityService.UpdateAttendanceEntity(attendanceEntity);
        }
        public void DeleteAttendance(Attendance attendanceToDelete)
        {
            var attendanceEntity = ConvertToEntity(attendanceToDelete);
            attendanceEntityService.DeleteAttendanceEntity(attendanceEntity);
        }

        private AttendanceEntity ConvertToEntity(Attendance attendance)
        {
            return new AttendanceEntity()
            {
                Id = attendance.AttendanceId,
                RegisteredSubjectId = attendance.RegisteredSubjectId,
                Name = attendance.Name,
                IsAttended = attendance.IsAttended,
                Date = attendance.Date,
                StartTime = attendance.StartTime,
                EndTime = attendance.EndTime
            };
        }

        private Attendance ConvertToModel(AttendanceEntity attendanceEntity)
        {
            var attendance = new Attendance(attendanceEntity.Name)
            {
                AttendanceId = attendanceEntity.Id,
                RegisteredSubjectId = attendanceEntity.RegisteredSubjectId,
                Name = attendanceEntity.Name,
                IsAttended = attendanceEntity.IsAttended,
                Date = attendanceEntity.Date,
                StartTime = attendanceEntity.StartTime,
                EndTime = attendanceEntity.EndTime
            };

            return attendance;
        }
    }
}
