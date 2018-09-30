using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pluto.BLL.Model;
using Pluto.BLL.Model.RegisteredSubjects;

namespace TestBLL.ModelTest
{
    [TestClass]
    public class SubjectTest
    {
        [TestMethod]
        public void CreateSubjectTest()
        {
            Subject subject = new Subject("TestSubject", 2);

            Assert.AreNotEqual(null, subject.Name);
            Assert.AreEqual(false, subject.IsRegistered);
            Assert.AreNotEqual(null, subject.RegisteredSubjects);
        }

        [TestMethod]
        public void RegisterSubjectTest()
        {
            Subject subject = new Subject("TestSubject", 2);
            RegisteredSubject registereSubject = subject.Register();

            Assert.AreNotEqual(null, registereSubject);
            Assert.AreEqual(1, subject.RegisteredSubjects.Count);
            Assert.AreEqual(true, subject.IsRegistered);
        }

        [TestMethod]
        public void RegisterSubjectTwiceTest()
        {
            Subject subject = new Subject("TestSubject", 2);
            RegisteredSubject registereSubject_1 = subject.Register();
            RegisteredSubject registereSubject_2 = subject.Register();

            Assert.AreNotEqual(null, registereSubject_1);
            Assert.AreEqual(null, registereSubject_2);
            Assert.AreEqual(1, subject.RegisteredSubjects.Count);
            Assert.AreEqual(true, subject.IsRegistered);
        }

        [TestMethod]
        public void RollbackRegistrationTest()
        {
            Subject subject = new Subject("TestSubject", 2);
            RegisteredSubject registereSubject = subject.Register();

            subject.RollbackRegistration(registereSubject);

            Assert.AreEqual(0, subject.RegisteredSubjects.Count);
            Assert.AreEqual(false, subject.IsRegistered);
        }

        [TestMethod]
        public void SubjectIsDeletableEmptyTest()
        {
            Subject subject = new Subject("TestSubject", 2);

            Assert.AreEqual(true, subject.IsDeletable);
        }

        [TestMethod]
        public void SubjectIsDeletableNotEmptyOpenTest()
        {
            Subject subject = new Subject("TestSubject", 2);
            subject.Register();

            Assert.AreEqual(false, subject.IsDeletable);
        }

        [TestMethod]
        public void SubjectIsDeletableNotEmptyClosedTest()
        {
            Subject subject = new Subject("TestSubject", 2);
            var registeredSubject = subject.Register();

            registeredSubject.Close();

            Assert.AreEqual(false, subject.IsDeletable);
        }

        [TestMethod]
        public void SubjectCompletedNotRegisteredTest()
        {
            Subject subject = new Subject("TestSubject", 2) { SubjectId = 1 };

            subject.IsCompleted = true;

            Assert.AreEqual(false, subject.IsCompleted);
        }

        [TestMethod]
        public void SubjectCompletedRegisteredTest()
        {
            Subject subject = new Subject("TestSubject", 2) { SubjectId = 1 };

            subject.Register();
            subject.IsCompleted = true;

            Assert.AreEqual(true, subject.IsCompleted);
        }

        [TestMethod]
        public void SubjectIsDeletableCompletedTest()
        {
            Subject subject = new Subject("TestSubject", 2) { SubjectId = 1 };

            subject.Register();
            subject.IsCompleted = true;

            Assert.AreEqual(false, subject.IsDeletable);
        }

        [TestMethod]
        public void SubjectIsDeletableCompletedClosedRegisteredSubjectTest()
        {
            Subject subject = new Subject("TestSubject", 2) { SubjectId = 1 };
            RegisteredSubject registeredSubject = subject.Register();

            subject.IsCompleted = true;
            registeredSubject.Close();

            Assert.AreEqual(false, subject.IsDeletable);
        }

        [TestMethod]
        public void UnregisterCompletedSubject()
        {
            Subject subject = new Subject("TestSubject", 2);
            RegisteredSubject registereSubject = subject.Register();

            registereSubject.IsCompleted = true;

            var result = subject.Unregister();

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void UnregisterIncompletedSubject()
        {
            Subject subject = new Subject("TestSubject", 2);
            RegisteredSubject registeredSubject = subject.Register();
            Term term = new Term("1. félév", true);

            term.RegisterSubject(registeredSubject);

            registeredSubject.IsCompleted = true;
            registeredSubject.IsCompleted = false;

            var result = subject.Unregister();

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void RegisterCompletedUnregisteredSubject()
        {
            Subject subject = new Subject("TestSubject", 2);
            RegisteredSubject registeredSubject_1 = subject.Register();
            Term term = new Term("1. félév", true);

            term.RegisterSubject(registeredSubject_1);

            registeredSubject_1.IsCompleted = true;

            term.Close();

            var registeredSubject_2 = subject.Register();

            Assert.AreEqual(false, subject.IsRegistered);
            Assert.AreEqual(true, subject.IsCompleted);
            Assert.AreEqual(null, registeredSubject_2);
        }
    }
}