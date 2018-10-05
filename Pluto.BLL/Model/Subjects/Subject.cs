using Pluto.BLL.Model.RegisteredSubjects;
using System;
using System.Collections.Generic;

namespace Pluto.BLL.Model.Subjects
{
    public class Subject : MyBindableBase
    {
        private int subjectId;
        public int SubjectId {
            get { return subjectId; }
            set { SetProperty(ref subjectId, value); }
        }

        private string name;
        public string Name {
            get { return name; }
            set { SetProperty(ref name, value, nameof(Name)); }
        }

        private int credit;
        public int Credit {
            get { return credit; }
            set
            {
                if (value != credit && RegisteredSubjects.Exists(s => s.IsClosed))
                    throw new InvalidOperationException("This subject has closed item.");

                SetProperty(ref credit, value, nameof(Credit));
            }
        }

        private bool isRegistered;
        public bool IsRegistered {
            get { return isRegistered; }
            set
            {
                SetProperty(ref isRegistered, value);
                if (value == false)
                {
                    ActualRegisteredSubject = null;
                    ActualRegisteredSubjectId = 0;
                }
            }
        }

        public bool IsDeletable
        {
            get { return RegisteredSubjects.Count == 0; }
        }

        private bool isCompleted;
        public bool IsCompleted
        {
            get { return isCompleted; }
            set
            {
                if (IsRegistered)
                    SetProperty(ref isCompleted, value);
            }
        }

        public int ActualRegisteredSubjectId { get; private set; }
        public RegisteredSubject ActualRegisteredSubject { get; private set; }

        public List<RegisteredSubject> RegisteredSubjects { get; private set; }

        public Subject(string name, int credit)
        {
            RegisteredSubjects = new List<RegisteredSubject>();
            Name = name;
            Credit = credit;
        }

        public RegisteredSubject Register()
        {
            if (IsRegistered || IsCompleted)
                return null;

            var registeredSubject = new RegisteredSubject(this);

            RegisteredSubjects.Add(registeredSubject);
            ActualRegisteredSubject = registeredSubject;
            IsRegistered = true;

            return registeredSubject;
        }
        public void RollbackRegistration(RegisteredSubject registeredSubject)
        {
            if (registeredSubject != null)
            {
                RegisteredSubjects.Remove(registeredSubject);
                IsRegistered = false;
            }
        }
        public bool Unregister()
        {
            if (IsRegistered && !IsCompleted)
            {
                bool result = ActualRegisteredSubject.Unregister();
                if (result)
                {
                    RegisteredSubjects.Remove(ActualRegisteredSubject);
                    IsRegistered = false;

                    return true;
                }
            }

            return false;
        }

        public void Load(int subjectId, bool isRegistered, bool isCompleted, int actualRegisteredSubjectId)
        {
            SubjectId = subjectId;
            IsRegistered = isRegistered;
            this.isCompleted = isCompleted;
            ActualRegisteredSubjectId = actualRegisteredSubjectId;
        }
        public void SetAssociations(RegisteredSubject registeredSubject, RegisteredSubject actualRegisteredSubject)
        {
            RegisteredSubjects.Add(registeredSubject);

            if(actualRegisteredSubject != null)
                ActualRegisteredSubject = actualRegisteredSubject;
        }
    }
}
