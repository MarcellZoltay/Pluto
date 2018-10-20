using Pluto.BLL.Model.RegisteredSubjects;
using Pluto.BLL.Model.Subjects;
using Pluto.BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pluto.BLL.Model
{
    public class DataManager
    {
        #region Singleton
        private static DataManager instance = new DataManager();
        public static DataManager Instance
        {
            get { return instance; }
        }

        private DataManager()
        {
            subjectMapperService = UnityBootstrapper.UnityBootstrapperInstance.Resolve<ISubjectMapperService>();
            termMapperService = UnityBootstrapper.UnityBootstrapperInstance.Resolve<ITermMapperService>();
            registeredSubjectMapperService = UnityBootstrapper.UnityBootstrapperInstance.Resolve<IRegisteredSubjectMapperService>();
            attendanceMapperService = UnityBootstrapper.UnityBootstrapperInstance.Resolve<IAttendanceMapperService>();

            subjects = new List<Subject>();
            terms = new List<Term>();
            registeredSubjects = new List<RegisteredSubject>();

            LoadSubject();
            LoadTerm();
            LoadRegisteredSubjects();

            SetAssociations();
        }
        #endregion

        private ISubjectMapperService subjectMapperService;
        private ITermMapperService termMapperService;
        private IRegisteredSubjectMapperService registeredSubjectMapperService;
        private IAttendanceMapperService attendanceMapperService;

        private List<Subject> subjects;
        private List<Term> terms;
        private List<RegisteredSubject> registeredSubjects;

        private void LoadSubject()
        {
            subjects = subjectMapperService.GetSubjects();
        }
        private void LoadTerm()
        {
            terms = termMapperService.GetTerms();
        }
        private void LoadRegisteredSubjects()
        {
            registeredSubjects = registeredSubjectMapperService.GetRegisteredSubjects();
        }
        private void SetAssociations()
        {
            foreach (var item in registeredSubjects)
            {
                var subject = subjects.Find(s => s.SubjectId == item.SubjectId);
                var term = terms.Find(t => t.TermId == item.TermId);

                item.SetAssociations(subject, term);

                subject.SetAssociations(
                    item, 
                    item.RegisteredSubjectId == subject.ActualRegisteredSubjectId ? item : null
                    );
                term.SetAssociations(item);
            }
        }

        
        public List<Term> GetTerms(Predicate<Term> predicate)
        {
            return predicate == null ? terms : terms.FindAll(predicate);
        }
        public void AddTerm(Term term)
        {
            terms.Add(term);
            termMapperService.AddTerm(term);
        }
        public void UpdateTerm(Term termToUpdate)
        {
            termMapperService.UpdateTerm(termToUpdate);
        }
        public void DeleteTerm(Term termtToDelete)
        {
           terms.Remove(termtToDelete);
           termMapperService.DeleteTerm(termtToDelete);
        }
        public void CloseTerm(Term termToClose)
        {
            termMapperService.UpdateTerm(termToClose);
            foreach (var item in termToClose.RegisteredSubjects)
            {
                registeredSubjectMapperService.UpdateRegisteredSubject(item);
                subjectMapperService.UpdateSubject(item.Subject);
            }
        }


        public List<Subject> GetSubjects()
        {
            return subjects;
        }
        public void AddSubject(Subject subject)
        {
            subjects.Add(subject);
            subjectMapperService.AddSubject(subject);
        }
        public void UpdateSubject(Subject subjectToUpdate)
        {
            subjectMapperService.UpdateSubject(subjectToUpdate);

            foreach (var item in subjectToUpdate.RegisteredSubjects)
            {
                UpdateRegisteredSubject(item);
            }
        }
        public void DeleteSubject(Subject subjectToDelete)
        {
            subjects.Remove(subjectToDelete);
            subjectMapperService.DeleteSubject(subjectToDelete);
        }


        public List<RegisteredSubject> GetRegisteredSubjects()
        {
            return registeredSubjects;
        }
        public void AddRegisteredSubject(RegisteredSubject registeredSubject)
        {
            registeredSubjects.Add(registeredSubject);
            registeredSubjectMapperService.AddRegisteredSubject(registeredSubject);
        }
        public void UpdateRegisteredSubject(RegisteredSubject registeredSubjectToUpdate)
        {
            registeredSubjectMapperService.UpdateRegisteredSubject(registeredSubjectToUpdate);
        }
        public void DeleteRegisteredSubject(RegisteredSubject registeredSubjectToDelete)
        {
            registeredSubjects.Remove(registeredSubjectToDelete);
            registeredSubjectMapperService.DeleteRegisteredSubject(registeredSubjectToDelete);
        }
        public void SetRegisteredSubjectCompletion(RegisteredSubject registeredSubjectToSet)
        {
            registeredSubjectMapperService.UpdateRegisteredSubject(registeredSubjectToSet);
            subjectMapperService.UpdateSubject(registeredSubjectToSet.Subject);
        }


        public void AddAttendance(Attendance attendance)
        {
            attendanceMapperService.AddAttendance(attendance);
        }
        public void UpdateAttendance(Attendance attendanceToUpdate)
        {
            attendanceMapperService.UpdateAttendance(attendanceToUpdate);
        }
        public void DeleteAttendance(Attendance attendanceToDelete)
        {
            attendanceMapperService.DeleteAttendance(attendanceToDelete);
        }
    }
}
