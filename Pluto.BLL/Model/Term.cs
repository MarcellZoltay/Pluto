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
            set { SetProperty(ref isActive, value); }
        }

        private List<RegisteredSubject> registeredSubjects;
        public List<RegisteredSubject> RegisteredSubjects
        {
            get { return registeredSubjects; }
        }

        public Term()
        {
            registeredSubjects = new List<RegisteredSubject>();
        }
        public Term(List<RegisteredSubject> registeredSubjects)
        {
            this.registeredSubjects = new List<RegisteredSubject>(registeredSubjects);
        }

        public bool RegisterSubject(RegisteredSubject registeredSubject)
        {
            if (isActive)
            {
                foreach (var subject in registeredSubjects)
                {
                    if (subject.SubjectId == registeredSubject.SubjectId)
                        return false;
                }

                registeredSubjects.Add(registeredSubject);
                registeredSubject.TermId = termId;

                return true;
            }

            return false;
        }
        public void UnregisterSubject(RegisteredSubject registeredSubject)
        {
            registeredSubjects.Remove(registeredSubject);
        }
    }
}
