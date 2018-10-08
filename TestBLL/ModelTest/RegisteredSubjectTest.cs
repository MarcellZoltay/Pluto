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
        private Term term;
        private Subject subject;
        private RegisteredSubject registeredSubject;

        private void Setup(bool isActive)
        {
            term = new Term("Test term", isActive, new Period(DateTime.Today, DateTime.Today)) { TermId = 1 };
            subject = new Subject("Test subject", 1) { SubjectId = 1 };
            registeredSubject = subject.Register();
        }

        [TestMethod]
        public void CreateRegisteredSubjectTest()
        {
            Setup(false);

            Assert.AreEqual(subject, registeredSubject.Subject);
            Assert.AreEqual(subject.SubjectId, registeredSubject.SubjectId);
            Assert.AreEqual("Test subject", registeredSubject.Name);
            Assert.AreEqual(1, registeredSubject.Credit);
        }

        [TestMethod]
        public void SetTermToRegisteredSubjectTest()
        {
            Setup(true);

            registeredSubject.Term = term;

            Assert.AreEqual(term, registeredSubject.Term);
            Assert.AreEqual(term.TermId, registeredSubject.TermId);
        }

        [TestMethod]
        public void CloseRegisteredSubjectTest()
        {
            Setup(false);

            registeredSubject.Close();

            Assert.AreEqual(true, registeredSubject.IsClosed);
            Assert.AreEqual(false, subject.IsRegistered);
        }

        [TestMethod]
        public void SetCompletedTrueNotClosedTest()
        {
            Setup(false);

            registeredSubject.IsCompleted = true;

            Assert.AreEqual(true, registeredSubject.IsCompleted);
        }

        [TestMethod]
        public void SetCompletedTrueClosedTest()
        {
            Setup(false);

            registeredSubject.Close();
            registeredSubject.IsCompleted = true;

            Assert.AreEqual(false, registeredSubject.IsCompleted);
        }

        [TestMethod]
        public void SetCompletedSetSubjectCompleted()
        {
            Setup(false);

            registeredSubject.IsCompleted = true;

            Assert.AreEqual(true, subject.IsCompleted);
        }
    }
}
