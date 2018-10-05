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
        [TestMethod]
        public void RegisterSubjectToActiveOpenTermTest()
        {
            RegisteredSubjectService subjectRegistrationService = new RegisteredSubjectService();

            Subject subject = new Subject("TestSubject", 4) { SubjectId = 1 };
            Term term = new Term("TestTerm", true) { TermId = 1 };

            subjectRegistrationService.RegisterSubjectAsync(subject, term);

            Assert.AreNotEqual(null, subject.RegisteredSubjects.FirstOrDefault(p => p.SubjectId == 1));
            Assert.AreEqual(true, subject.IsRegistered);
            Assert.AreNotEqual(null, term.RegisteredSubjects.FirstOrDefault(p => p.TermId == 1));
        }

        [TestMethod]
        public void RegisterSubjectToActiveClosedTermTest()
        {
            RegisteredSubjectService subjectRegistrationService = new RegisteredSubjectService();

            Subject subject = new Subject("TestSubject", 4) { SubjectId = 1 };
            Term term = new Term("TestTerm", true) { TermId = 1 };
            term.Close();

            subjectRegistrationService.RegisterSubjectAsync(subject, term);

            Assert.AreEqual(null, subject.RegisteredSubjects.FirstOrDefault(p => p.SubjectId == 1));
            Assert.AreEqual(null, term.RegisteredSubjects.FirstOrDefault(p => p.TermId == 1));
        }

        [TestMethod]
        public void RegisterSubjectToPassiveTermTest()
        {
            RegisteredSubjectService subjectRegistrationService = new RegisteredSubjectService();

            Subject subject = new Subject("TestSubject", 4) { SubjectId = 1 };
            Term term = new Term("TestTerm", false) { TermId = 1 };

            subjectRegistrationService.RegisterSubjectAsync(subject, term);

            Assert.AreEqual(null, subject.RegisteredSubjects.FirstOrDefault(p => p.SubjectId == 1));
            Assert.AreEqual(null, term.RegisteredSubjects.FirstOrDefault(p => p.TermId == 1));
        }

        [TestMethod]
        public void UnregisterSubjectTermActiveOpenTest()
        {
            RegisteredSubjectService subjectRegistrationService = new RegisteredSubjectService();

            Subject subject = new Subject("TestSubject", 4) { SubjectId = 1 };
            Term term = new Term("TestTerm", true) { TermId = 1 };

            subjectRegistrationService.RegisterSubjectAsync(subject, term);

            subjectRegistrationService.UnregisterSubjectAsync(subject);

            Assert.AreEqual(0, term.RegisteredSubjects.Count);
            Assert.AreEqual(0, subject.RegisteredSubjects.Count);
            Assert.AreEqual(false, subject.IsRegistered);
        }

        [TestMethod]
        public void UnregisterSubjectTermActiveClosedTest()
        {
            RegisteredSubjectService subjectRegistrationService = new RegisteredSubjectService();

            Subject subject = new Subject("TestSubject", 4) { SubjectId = 1 };
            Term term = new Term("TestTerm", true) { TermId = 1 };

            subjectRegistrationService.RegisterSubjectAsync(subject, term);

            term.Close();

            subjectRegistrationService.UnregisterSubjectAsync(subject);

            Assert.AreEqual(1, term.RegisteredSubjects.Count);
            Assert.AreEqual(1, subject.RegisteredSubjects.Count);
            Assert.AreEqual(false, subject.IsRegistered);
        }
    }
}
