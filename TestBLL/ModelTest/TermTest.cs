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
        private Term term;
        private Subject subject;
        private RegisteredSubject registeredSubject;

        private void Setup(bool isActive, Period period = null)
        {
            term = new Term("Test term", isActive, period);
            subject = new Subject("Test subject", 1);
            registeredSubject = subject.Register();
        }

        private Period GetValidDate()
        {
            return new Period(DateTime.Today, DateTime.Today);
        }

        [TestMethod]
        public void CreateActiveRightDateTermTest()
        {
            Setup(true, GetValidDate());

            Assert.AreNotEqual(null, term.Name);
            Assert.AreEqual(true, term.IsActive);
            Assert.AreNotEqual(null, term.RegisteredSubjects);
            Assert.AreEqual(false, term.IsClosed);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CreateActiveWrongDateTermTest()
        {
            Setup(true, new Period(new DateTime(2018, 1, 1), new DateTime(2017, 1, 1)));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateActiveNullDateTermTest()
        {
            Setup(true);
        }

        [TestMethod]
        public void CreatePassiveTermWithDateTest()
        {
            Setup(false);

            Assert.AreEqual(false, term.IsActive);
            Assert.AreEqual(null, term.Period);
        }

        [TestMethod]
        public void RegisterSubjectTermNotActiveOpenTest()
        {
            Setup(false);

            var succeeded = term.RegisterSubject(registeredSubject);
            Assert.AreEqual(false, succeeded);
            Assert.AreEqual(0, term.RegisteredSubjects.Count);
        }

        [TestMethod]
        public void RegisterSubjectTermActiveOpenTest()
        {
            Setup(true, GetValidDate());

            var succeeded = term.RegisterSubject(registeredSubject);
            Assert.AreEqual(true, succeeded);
            Assert.AreEqual(1, term.RegisteredSubjects.Count);
        }

        [TestMethod]
        public void RegisterSubjectTermActiveClosedTest()
        {
            Setup(true, GetValidDate());

            term.Close();

            var succeeded = term.RegisterSubject(registeredSubject);
            Assert.AreEqual(false, succeeded);
            Assert.AreEqual(0, term.RegisteredSubjects.Count);
        }

        [TestMethod]
        public void CloseTermTest()
        {
            Setup(true, GetValidDate());

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
            Setup(false);

            term.RegisterSubject(registeredSubject);
            var succeeded = term.UnregisterSubject(registeredSubject);

            Assert.AreEqual(false, succeeded);
        }

        [TestMethod]
        public void UnregisterSubjectTermActiveOpenTest()
        {
            Setup(true, GetValidDate());

            term.RegisterSubject(registeredSubject);
            var succeeded = term.UnregisterSubject(registeredSubject);

            Assert.AreEqual(true, succeeded);
        }

        [TestMethod]
        public void UnregisterSubjectTermActiveClosedTest()
        {
            Setup(true, GetValidDate());

            term.RegisterSubject(registeredSubject);

            term.Close();

            var succeeded = term.UnregisterSubject(registeredSubject);

            Assert.AreEqual(false, succeeded);
        }

        [TestMethod]
        public void TermIsDeletableOpenEmptyTest()
        {
            Setup(true, GetValidDate());

            Assert.AreEqual(true, term.IsDeletable);
        }

        [TestMethod]
        public void TermIsDeletableOpenNotEmptyTest()
        {
            Setup(true, GetValidDate());

            term.RegisterSubject(registeredSubject);

            Assert.AreEqual(false, term.IsDeletable);
        }

        [TestMethod]
        public void TermIsDeletableClosedEmptyTest()
        {
            Setup(true, GetValidDate());

            term.Close();

            Assert.AreEqual(false, term.IsDeletable);
        }

        [TestMethod]
        public void TermSetActiveFromPassiveTest()
        {
            Setup(false);

            term.SetActive(new Period(DateTime.Today, DateTime.Today));

            Assert.AreEqual(true, term.IsActive);
        }

        [TestMethod]
        public void TermSetPassiveFromActiveNotClosedEmptyTest()
        {
            Setup(true, GetValidDate());

            term.SetPassive();

            Assert.AreEqual(false, term.IsActive);
            Assert.AreEqual(null, term.Period);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TermSetPassiveFromActiveClosedEmptyTest()
        {
            Setup(true, GetValidDate());

            term.Close();
            term.SetPassive();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TermSetPassiveFromActiveNotClosedNotEmptyTest()
        {
            Setup(true, GetValidDate());

            term.RegisterSubject(registeredSubject);

            term.SetPassive();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TermSetInvalidPeriodTest()
        {
            Setup(true, GetValidDate());

            term.Period.StartDate = new DateTime(2019, 1, 1);
        }
    }
}
