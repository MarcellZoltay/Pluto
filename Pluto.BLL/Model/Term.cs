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
            private set
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

        private Period period;
        public Period Period
        {
            get { return period; }
            private set { SetProperty(ref period, value); }
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

        private int registeredCredits;
        public int RegisteredCredits
        {
            get { return registeredCredits; }
            private set { SetProperty(ref registeredCredits, value); }
        }

        public Term(string name, bool isActive, Period period)
        {
            Name = name;

            if (isActive)
                SetActive(period);

            registeredSubjects = new ObservableCollection<RegisteredSubject>();
            IsClosed = false;
        }

        public bool RegisterSubject(RegisteredSubject registeredSubject)
        {
            if (isActive && !IsClosed && registeredSubject != null)
            {
                registeredSubjects.Add(registeredSubject);
                registeredSubject.Term = this;

                RegisteredCredits += registeredSubject.Credit;

                return true;
            }

            return false;
        }
        public bool UnregisterSubject(RegisteredSubject registeredSubject)
        {
            if (IsActive && !IsClosed)
            {
                registeredSubjects.Remove(registeredSubject);

                RegisteredCredits -= registeredSubject.Credit;

                return true;
            }

            return false;
        }

        public void SetActive(Period period)
        {
            if (period == null)
                throw new ArgumentNullException("Period cannot be null.");
            
            IsActive = true;
            Period = period;
        }
        public void SetPassive()
        {
            IsActive = false;
            Period = null;
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

            RegisteredCredits += registeredSubject.Credit;
        }
    }
}
