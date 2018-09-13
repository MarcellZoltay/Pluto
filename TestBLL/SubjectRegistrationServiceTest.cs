using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pluto.BLL.Model;
using Pluto.BLL.Services;

namespace TestBLL
{
    [TestClass]
    public class SubjectRegistrationServiceTest
    {
        [TestMethod]
        public void RegisterSubject()
        {
            SubjectRegistrationService subjectRegistrationService = new SubjectRegistrationService();

            Subject subject = new Subject() { SubjectId = 1, Name = "TestSubject", Credit = 4 };
            Term term = new Term() { TermId = 1, Name = "TestTerm", IsActive = true };

            subjectRegistrationService.RegisterSubject(subject, term);

            Assert.AreNotEqual(null, subject.RegisteredSubjects.Find(p => p.SubjectId == 1));
            Assert.AreNotEqual(null, term.RegisteredSubjects.Find(p => p.TermId == 1));
        }

        [TestMethod]
        public void RegisterAlreadyRegisteredSubject()
        {
            SubjectRegistrationService subjectRegistrationService = new SubjectRegistrationService();

            Subject subject = new Subject() { SubjectId = 1, Name = "TestSubject", Credit = 4 };
            Term term = new Term() { TermId = 1, Name = "TestTerm", IsActive = true };

            subjectRegistrationService.RegisterSubject(subject, term);

            subjectRegistrationService.RegisterSubject(subject, term);

            Assert.AreEqual(1, subject.RegisteredSubjects.FindAll(p => p.SubjectId == 1).Count);
            Assert.AreEqual(1, term.RegisteredSubjects.FindAll(p => p.TermId == 1).Count);
        }

        [TestMethod]
        public void RegisterSubjectToClosedTerm()
        {
        }
    }
}
