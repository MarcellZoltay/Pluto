using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pluto.BLL.Model;
using Pluto.BLL.Model.Subjects;
using Pluto.BLL.Services.Implementations;

namespace TestBLL
{
    [TestClass]
    public class SubjectRegistrationServiceTest
    {
        private Term term;
        private Subject subject;
        private RegisteredSubjectService registeredSubjectService;

        private void Setup(bool isActive)
        {
            term = new Term("Test term", isActive, new Period(DateTime.Today, DateTime.Today)) { TermId = 1 };
            subject = new Subject("Test subject", 1) { SubjectId = 1 };
            registeredSubjectService = new RegisteredSubjectService();
        }

        [TestMethod]
        public void RegisterSubjectToActiveOpenTermTest()
        {
            Setup(true);

            registeredSubjectService.RegisterSubjectAsync(subject, term);

            Assert.AreNotEqual(null, subject.RegisteredSubjects.FirstOrDefault(p => p.SubjectId == 1));
            Assert.AreEqual(true, subject.IsRegistered);
            Assert.AreNotEqual(null, term.RegisteredSubjects.FirstOrDefault(p => p.TermId == 1));
        }

        [TestMethod]
        public void RegisterSubjectToActiveClosedTermTest()
        {
            Setup(true);

            term.Close();

            registeredSubjectService.RegisterSubjectAsync(subject, term);

            Assert.AreEqual(null, subject.RegisteredSubjects.FirstOrDefault(p => p.SubjectId == 1));
            Assert.AreEqual(null, term.RegisteredSubjects.FirstOrDefault(p => p.TermId == 1));
        }

        [TestMethod]
        public void RegisterSubjectToPassiveTermTest()
        {
            Setup(false);

            registeredSubjectService.RegisterSubjectAsync(subject, term);

            Assert.AreEqual(null, subject.RegisteredSubjects.FirstOrDefault(p => p.SubjectId == 1));
            Assert.AreEqual(null, term.RegisteredSubjects.FirstOrDefault(p => p.TermId == 1));
        }

        [TestMethod]
        public void UnregisterSubjectTermActiveOpenTest()
        {
            Setup(true);

            registeredSubjectService.RegisterSubjectAsync(subject, term);

            registeredSubjectService.UnregisterSubjectAsync(subject);

            Assert.AreEqual(0, term.RegisteredSubjects.Count);
            Assert.AreEqual(0, subject.RegisteredSubjects.Count);
            Assert.AreEqual(false, subject.IsRegistered);
        }

        [TestMethod]
        public void UnregisterSubjectTermActiveClosedTest()
        {
            Setup(true);

            registeredSubjectService.RegisterSubjectAsync(subject, term);

            term.Close();

            registeredSubjectService.UnregisterSubjectAsync(subject);

            Assert.AreEqual(1, term.RegisteredSubjects.Count);
            Assert.AreEqual(1, subject.RegisteredSubjects.Count);
            Assert.AreEqual(false, subject.IsRegistered);
        }
    }
}
