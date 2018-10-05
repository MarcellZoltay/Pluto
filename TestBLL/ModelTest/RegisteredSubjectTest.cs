using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pluto.BLL.Model;
using Pluto.BLL.Model.RegisteredSubjects;
using Pluto.BLL.Model.Subjects;

namespace TestBLL.ModelTest
{
    [TestClass]
    public class RegisteredSubjectTest
    {
        [TestMethod]
        public void CreateRegisteredSubjectTest()
        {
            Subject subject = new Subject("TestSubject", 2) { SubjectId = 1 };
            RegisteredSubject registeredSubject = subject.Register();

            Assert.AreEqual(subject, registeredSubject.Subject);
            Assert.AreEqual(subject.SubjectId, registeredSubject.SubjectId);
            Assert.AreEqual("TestSubject", registeredSubject.Name);
            Assert.AreEqual(2, registeredSubject.Credit);
        }

        [TestMethod]
        public void SetTermToRegisteredSubjectTest()
        {
            Subject subject = new Subject("TestSubject", 2) { SubjectId = 1 };
            RegisteredSubject registeredSubject = subject.Register();
            Term term = new Term("TestTerm", true) { TermId = 1 };

            registeredSubject.Term = term;

            Assert.AreEqual(term, registeredSubject.Term);
            Assert.AreEqual(term.TermId, registeredSubject.TermId);
        }

        [TestMethod]
        public void CloseRegisteredSubjectTest()
        {
            Subject subject = new Subject("TestSubject", 2) { SubjectId = 1 };
            RegisteredSubject registeredSubject = subject.Register();
            registeredSubject.Close();

            Assert.AreEqual(true, registeredSubject.IsClosed);
            Assert.AreEqual(false, subject.IsRegistered);
        }

        [TestMethod]
        public void SetCompletedTrueNotClosedTest()
        {
            Subject subject = new Subject("TestSubject", 2) { SubjectId = 1 };
            RegisteredSubject registeredSubject = subject.Register();

            registeredSubject.IsCompleted = true;

            Assert.AreEqual(true, registeredSubject.IsCompleted);
        }

        [TestMethod]
        public void SetCompletedTrueClosedTest()
        {
            Subject subject = new Subject("TestSubject", 2) { SubjectId = 1 };
            RegisteredSubject registeredSubject = subject.Register();

            registeredSubject.Close();
            registeredSubject.IsCompleted = true;

            Assert.AreEqual(false, registeredSubject.IsCompleted);
        }

        [TestMethod]
        public void SetCompletedSetSubjectCompleted()
        {
            Subject subject = new Subject("TestSubject", 2) { SubjectId = 1 };
            RegisteredSubject registeredSubject = subject.Register();

            registeredSubject.IsCompleted = true;

            Assert.AreEqual(true, subject.IsCompleted);
        }
    }
}
