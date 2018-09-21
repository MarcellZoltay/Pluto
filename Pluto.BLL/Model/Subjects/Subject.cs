using Pluto.BLL.Model.RegisteredSubjects;
using System.Collections.Generic;

namespace Pluto.BLL.Model
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
            set { SetProperty(ref name, value); }
        }

        private int credit;
        public int Credit {
            get { return credit; }
            set { SetProperty(ref credit, value); }
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
            get
            {
                return RegisteredSubjects.Count == 0;
            }
        }

        public int ActualRegisteredSubjectId { get; private set; }
        public RegisteredSubject ActualRegisteredSubject { get; private set; }

        public List<RegisteredSubject> RegisteredSubjects { get; private set; }

        public Subject(string name, int credit)
        {
            Name = name;
            Credit = credit;
            RegisteredSubjects = new List<RegisteredSubject>();
        }

        public RegisteredSubject Register()
        {
            if (IsRegistered)
                return null;

            var registeredSubject = new RegisteredSubject(this);

            RegisteredSubjects.Add(registeredSubject);
            ActualRegisteredSubject = registeredSubject;
            IsRegistered = true;

            return registeredSubject;
        }
        public void RollbackRegistration(RegisteredSubject registeredSubject)
        {
            RegisteredSubjects.Remove(registeredSubject);
            IsRegistered = false;
        }
        public bool Unregister()
        {
            if (IsRegistered)
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

        public void Load(int subjectId, bool isRegistered, int actualRegisteredSubjectId)
        {
            SubjectId = subjectId;
            IsRegistered = isRegistered;
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
