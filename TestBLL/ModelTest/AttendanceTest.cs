using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pluto.BLL.Model;

namespace TestBLL.ModelTest
{
    [TestClass]
    public class AttendanceTest
    {
        private Attendance attendance;

        public void Setup()
        {
            attendance = new Attendance("Attendance Test");
        }

        [TestMethod]
        public void CreateAttendanceTest()
        {
            Setup();

            Assert.AreEqual("Attendance Test", attendance.Name);
            Assert.AreEqual(false, attendance.IsAttended);
        }

        [TestMethod]
        public void SetDateTest()
        {
            Setup();

            attendance.Date = new DateTime(2018, 1, 1);

            Assert.AreEqual(2018, attendance.Date.Year);
            Assert.AreEqual(1, attendance.Date.Month);
            Assert.AreEqual(1, attendance.Date.Day);
        }

        [TestMethod]
        public void SetStartTimeTest()
        {
            Setup();

            attendance.StartTime = new TimeSpan(10, 0, 0);

            Assert.AreEqual(10, attendance.StartTime.Hours);
            Assert.AreEqual(0, attendance.StartTime.Minutes);
            Assert.AreEqual(0, attendance.StartTime.Seconds);
        }

        [TestMethod]
        public void SetDateAndStartAndEndTimeTest()
        {
            Setup();

            attendance.Date = new DateTime(2018, 1, 1);
            attendance.StartTime = new TimeSpan(10, 15, 0);
            attendance.EndTime = new TimeSpan(12, 0, 0);

            Assert.AreEqual(2018, attendance.Date.Year);
            Assert.AreEqual(1, attendance.Date.Month);
            Assert.AreEqual(1, attendance.Date.Day);
            Assert.AreEqual(10, attendance.StartTime.Hours);
            Assert.AreEqual(15, attendance.StartTime.Minutes);
            Assert.AreEqual(0, attendance.StartTime.Seconds);
            Assert.AreEqual(12, attendance.EndTime.Hours);
            Assert.AreEqual(0, attendance.EndTime.Minutes);
            Assert.AreEqual(0, attendance.EndTime.Seconds);
        }
    }
}
