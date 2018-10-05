using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pluto.BLL.Model;
using Pluto.BLL.Model.RegisteredSubjects;
using Pluto.BLL.Model.Subjects;

namespace TestBLL.ModelTest
{
    [TestClass]
    public class TermTest
    {
        [TestMethod]
        public void CreateTermTest()
        {
            Term term = new Term("1. félév", false);

            Assert.AreNotEqual(null, term.Name);
            Assert.AreEqual(false, term.IsActive);
            Assert.AreNotEqual(null, term.RegisteredSubjects);
            Assert.AreEqual(false, term.IsClosed);
        }

        [TestMethod]
        public void RegisterSubjectTermNotActiveOpenTest()
        {
            Subject subject = new Subject("TestSubject", 2);
            RegisteredSubject registeredSubject = new RegisteredSubject(subject);
            Term term = new Term("1. félév", false);

            var succeeded = term.RegisterSubject(registeredSubject);
            Assert.AreEqual(false, succeeded);
            Assert.AreEqual(0, term.RegisteredSubjects.Count);
        }

        [TestMethod]
        public void RegisterSubjectTermActiveOpenTest()
        {
            Subject subject = new Subject("TestSubject", 2);
            RegisteredSubject registeredSubject = new RegisteredSubject(subject);
            Term term = new Term("1. félév", true);

            var succeeded = term.RegisterSubject(registeredSubject);
            Assert.AreEqual(true, succeeded);
            Assert.AreEqual(1, term.RegisteredSubjects.Count);
        }

        [TestMethod]
        public void RegisterSubjectTermActiveClosedTest()
        {
            Subject subject = new Subject("TestSubject", 2);
            RegisteredSubject registeredSubject = new RegisteredSubject(subject);
            Term term = new Term("1. félév", true);
            term.Close();

            var succeeded = term.RegisterSubject(registeredSubject);
            Assert.AreEqual(false, succeeded);
            Assert.AreEqual(0, term.RegisteredSubjects.Count);
        }

        [TestMethod]
        public void CloseTermTest()
        {
            Subject subject = new Subject("TestSubject", 2);
            Term term = new Term("1. félév", true);

            for(int i = 1; i < 4; i++)
            {
                term.RegisterSubject(new RegisteredSubject(subject));
            }

            Assert.AreEqual(3, term.RegisteredSubjects.Count);

            term.Close();

            bool succeeded = true;
            foreach (var item in term.RegisteredSubjects)
            {
                if (!item.IsClosed)
                    succeeded = false;
            }

            Assert.AreEqual(true, succeeded);
            Assert.AreEqual(true, term.IsClosed);
        }

        [TestMethod]
        public void UnregisterSubjectTermPassiveTest()
        {
            Subject subject = new Subject("TestSubject", 2);
            RegisteredSubject registeredSubject = new RegisteredSubject(subject);
            Term term = new Term("1. félév", false);

            term.RegisterSubject(registeredSubject);
            var succeeded = term.UnregisterSubject(registeredSubject);

            Assert.AreEqual(false, succeeded);
        }

        [TestMethod]
        public void UnregisterSubjectTermActiveOpenTest()
        {
            Subject subject = new Subject("TestSubject", 2);
            RegisteredSubject registeredSubject = new RegisteredSubject(subject);
            Term term = new Term("1. félév", true);

            term.RegisterSubject(registeredSubject);
            var succeeded = term.UnregisterSubject(registeredSubject);

            Assert.AreEqual(true, succeeded);
        }

        [TestMethod]
        public void UnregisterSubjectTermActiveClosedTest()
        {
            Subject subject = new Subject("TestSubject", 2);
            RegisteredSubject registeredSubject = new RegisteredSubject(subject);
            Term term = new Term("1. félév", true);

            term.RegisterSubject(registeredSubject);

            term.Close();

            var succeeded = term.UnregisterSubject(registeredSubject);

            Assert.AreEqual(false, succeeded);
        }

        [TestMethod]
        public void TermIsDeletableOpenEmptyTest()
        {
            Term term = new Term("1. félév", true);

            Assert.AreEqual(true, term.IsDeletable);
        }

        [TestMethod]
        public void TermIsDeletableOpenNotEmptyTest()
        {
            Subject subject = new Subject("TestSubject", 2);
            RegisteredSubject registeredSubject = new RegisteredSubject(subject);
            Term term = new Term("1. félév", true);

            term.RegisterSubject(registeredSubject);

            Assert.AreEqual(false, term.IsDeletable);
        }

        [TestMethod]
        public void TermIsDeletableClosedEmptyTest()
        {
            Term term = new Term("1. félév", true);
            term.Close();

            Assert.AreEqual(false, term.IsDeletable);
        }

        [TestMethod]
        public void TermSetActiveFromPassiveTest()
        {
            Term term = new Term("Test term", false);

            term.IsActive = true;

            Assert.AreEqual(true, term.IsActive);
        }

        [TestMethod]
        public void TermSetPassiveFromActiveNotClosedEmptyTest() {
            Term term = new Term("Test term", true);

            term.IsActive = false;

            Assert.AreEqual(false, term.IsActive);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TermSetPassiveFromActiveClosedEmptyTest()
        {
            Term term = new Term("Test term", true);

            term.Close();
            term.IsActive = false;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TermSetPassiveFromActiveNotClosedNotEmptyTest()
        {
            Subject subject = new Subject("TestSubject", 2);
            RegisteredSubject registeredSubject = new RegisteredSubject(subject);
            Term term = new Term("Test term", true);

            term.RegisterSubject(registeredSubject);

            term.IsActive = false;
        }
    }
}
