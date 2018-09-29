using Pluto.BLL.Model.RegisteredSubjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluto.BLL.Model
{
    public class Term : MyBindableBase
    {
        private int termId;
        public int TermId {
            get { return termId; }
            set { SetProperty(ref termId, value); }
        }

        private string name;
        public string Name {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private bool isActive;
        public bool IsActive {
            get { return isActive; }
            set
            {
                if (isActive == true && value == false)
                {
                    if(IsClosed)
                        throw new InvalidOperationException("This term has closed.");
                    else if (RegisteredSubjects.Count != 0)
                        throw new InvalidOperationException("This term has registered subjects.");
                }

                SetProperty(ref isActive, value);
            }
        }

        private bool isClosed;
        public bool IsClosed
        {
            get { return isClosed; }
            private set
            {
                if(IsActive)
                    SetProperty(ref isClosed, value);
            }
        }

        public bool IsDeletable
        {
            get { return !IsClosed && registeredSubjects.Count == 0; }
        }

        private ObservableCollection<RegisteredSubject> registeredSubjects;
        public ObservableCollection<RegisteredSubject> RegisteredSubjects
        {
            get { return registeredSubjects; }
        }

        public Term(string name, bool isActive)
        {
            Name = name;
            IsActive = isActive;
            registeredSubjects = new ObservableCollection<RegisteredSubject>();
            IsClosed = false;
        }

        public bool RegisterSubject(RegisteredSubject registeredSubject)
        {
            if (isActive && !IsClosed)
            {
                registeredSubjects.Add(registeredSubject);
                registeredSubject.Term = this;

                return true;
            }

            return false;
        }
        public bool UnregisterSubject(RegisteredSubject registeredSubject)
        {
            if (IsActive && !IsClosed)
            {
                registeredSubjects.Remove(registeredSubject);

                return true;
            }

            return false;
        }

        public void Close()
        {
            foreach (var subject in registeredSubjects)
            {
                subject.Close();
            }

            IsClosed = true;
        }

        public void Load(int termId, bool isClosed)
        {
            TermId = termId;
            IsClosed = isClosed;
        }
        public void SetAssociations(RegisteredSubject registeredSubject)
        {
            RegisteredSubjects.Add(registeredSubject);
        }
    }
}
