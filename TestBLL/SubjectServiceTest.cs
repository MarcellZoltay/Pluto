using Pluto.BLL.Model;
using Pluto.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBLL
{
    [TestClass]
    public class SubjectServiceTest
    {
        [TestMethod]
        public void GetSubjectsTest()
        {
            //ISubjectService subjectService = new SubjectService();
            //var task = subjectService.GetSubjects();
            //Task.WaitAll(task);

            var subjects = Model.Instance.GetSubjects();

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotEqual(0, subjects.Count);
        }
    }
}
