using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pluto.BLL.Model;
using Pluto.BLL.Model.RegisteredSubjects;
using Pluto.BLL.Model.Subjects;

namespace TestBLL.ModelTest
{
    [TestClass]
    public class SubjectTest
    {
        private Term term;
        private Subject subject;
        private RegisteredSubject registeredSubject;

        private void Setup(bool isActive)
        {
            term = new Term("Test term", isActive, new Period(DateTime.Today, DateTime.Today)) { TermId = 1 };
            subject = new Subject("Test subject", 1) { SubjectId = 1 };
        }

        [TestMethod]
        public void CreateSubjectTest()
        {
            Setup(false);

            Assert.AreNotEqual(null, subject.Name);
            Assert.AreEqual(false, subject.IsRegistered);
            Assert.AreNotEqual(null, subject.RegisteredSubjects);
        }

        [TestMethod]
        public void RegisterSubjectTest()
        {
            Setup(false);

            registeredSubject = subject.Register();

            Assert.AreNotEqual(null, registeredSubject);
            Assert.AreEqual(1, subject.RegisteredSubjects.Count);
            Assert.AreEqual(true, subject.IsRegistered);
        }

        [TestMethod]
        public void RegisterSubjectTwiceTest()
        {
            Setup(false);

            registeredSubject = subject.Register();

            RegisteredSubject registeredSubject_2 = subject.Register();

            Assert.AreNotEqual(null, registeredSubject);
            Assert.AreEqual(null, registeredSubject_2);
            Assert.AreEqual(1, subject.RegisteredSubjects.Count);
            Assert.AreEqual(true, subject.IsRegistered);
        }

        [TestMethod]
        public void RollbackRegistrationTest()
        {
            Setup(false);

            registeredSubject = subject.Register();

            subject.RollbackRegistration(registeredSubject);

            Assert.AreEqual(0, subject.RegisteredSubjects.Count);
            Assert.AreEqual(false, subject.IsRegistered);
        }

        [TestMethod]
        public void SubjectIsDeletableEmptyTest()
        {
            Setup(false);

            Assert.AreEqual(true, subject.IsDeletable);
        }

        [TestMethod]
        public void SubjectIsDeletableNotEmptyOpenTest()
        {
            Setup(false);

            registeredSubject = subject.Register();

            Assert.AreEqual(false, subject.IsDeletable);
        }

        [TestMethod]
        public void SubjectIsDeletableNotEmptyClosedTest()
        {
            Setup(false);

            registeredSubject = subject.Register();

            registeredSubject.Close();

            Assert.AreEqual(false, subject.IsDeletable);
        }

        [TestMethod]
        public void SubjectCompletedNotRegisteredTest()
        {
            Setup(false);

            subject.IsCompleted = true;

            Assert.AreEqual(false, subject.IsCompleted);
        }

        [TestMethod]
        public void SubjectCompletedRegisteredTest()
        {
            Setup(false);

            registeredSubject = subject.Register();

            subject.IsCompleted = true;

            Assert.AreEqual(true, subject.IsCompleted);
        }

        [TestMethod]
        public void SubjectIsDeletableCompletedTest()
        {
            Setup(false);

            registeredSubject = subject.Register();

            subject.IsCompleted = true;

            Assert.AreEqual(false, subject.IsDeletable);
        }

        [TestMethod]
        public void SubjectIsDeletableCompletedClosedRegisteredSubjectTest()
        {
            Setup(false);

            registeredSubject = subject.Register();

            registeredSubject.IsCompleted = true;
            registeredSubject.Close();

            Assert.AreEqual(false, subject.IsDeletable);
        }

        [TestMethod]
        public void UnregisterCompletedSubject()
        {
            Setup(false);

            registeredSubject = subject.Register();

            registeredSubject.IsCompleted = true;

            var result = subject.Unregister();

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void UnregisterIncompletedSubject()
        {
            Setup(true);

            registeredSubject = subject.Register();

            term.RegisterSubject(registeredSubject);

            var result = subject.Unregister();

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void RegisterCompletedUnregisteredSubject()
        {
            Setup(true);

            registeredSubject = subject.Register();

            term.RegisterSubject(registeredSubject);

            registeredSubject.IsCompleted = true;

            term.Close();

            var registeredSubject_2 = subject.Register();

            Assert.AreEqual(false, subject.IsRegistered);
            Assert.AreEqual(true, subject.IsCompleted);
            Assert.AreEqual(null, registeredSubject_2);
        }
    }
}