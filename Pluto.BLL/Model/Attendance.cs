using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluto.BLL.Model
{
    public class Attendance : MyBindableBase
    {
        private int attendanceId;
        public int AttendanceId
        {
            get { return attendanceId; }
            set { SetProperty(ref attendanceId, value); }
        }

        private int registeredSubjectId;
        public int RegisteredSubjectId
        {
            get { return registeredSubjectId; }
            set { SetProperty(ref registeredSubjectId, value); }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private bool isAttended;
        public bool IsAttended
        {
            get { return isAttended; }
            set { SetProperty(ref isAttended, value); }
        }

        private DateTime startDateTime;
        private DateTime endDateTime;

        public DateTime Date
        {
            get => startDateTime.Date;
            set
            {
                var startDateTimeTemp = new DateTime(value.Year, value.Month, value.Day, startDateTime.Hour, startDateTime.Minute, startDateTime.Second);
                var endDateTimeTemp = new DateTime(value.Year, value.Month, value.Day, endDateTime.Hour, endDateTime.Minute, endDateTime.Second);

                SetProperty(ref startDateTime, startDateTimeTemp);
                SetProperty(ref endDateTime, endDateTimeTemp);
            }
        }
        public TimeSpan StartTime
        {
            get => startDateTime.TimeOfDay;
            set
            {
                var startDateTimeTemp = new DateTime(startDateTime.Year, startDateTime.Month, startDateTime.Day, value.Hours, value.Minutes, value.Seconds);

                SetProperty(ref startDateTime, startDateTimeTemp);
            }
        }
        public TimeSpan EndTime
        {
            get => endDateTime.TimeOfDay;
            set
            {
                var endDateTimeTemp = new DateTime(endDateTime.Year, endDateTime.Month, endDateTime.Day, value.Hours, value.Minutes, value.Seconds);

                SetProperty(ref endDateTime, endDateTimeTemp);
            }
        }

        public Attendance(string name)
        {
            Name = name;
        }
    }
}
