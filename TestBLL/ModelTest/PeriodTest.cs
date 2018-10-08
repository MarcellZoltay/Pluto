using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pluto.BLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBLL.ModelTest
{
    [TestClass]
    public class PeriodTest
    {
        [TestMethod]
        public void SetDateTest()
        {
            var period = new Period(new DateTime(2018, 1, 1), new DateTime(2018, 2, 2));

            Assert.AreEqual(true, period.StartDate < period.EndDate);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SetSmallerEndDateTest()
        {
            var period = new Period(new DateTime(2018, 1, 1), new DateTime(2018, 2, 2));

            period.EndDate = new DateTime(2017, 1, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SetGreaterStartDateTest()
        {
            var period = new Period(new DateTime(2018, 1, 1), new DateTime(2018, 2, 2));

            period.StartDate = new DateTime(2019, 1, 1);
        }
    }
}
