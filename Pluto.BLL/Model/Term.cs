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

        private ObservableCollection<RegisteredSubject> registeredSubjects;
        public IReadOnlyCollection<RegisteredSubject> RegisteredSubjects
        {
            get { return registeredSubjects; }
        }

        public Term()
        {
            registeredSubjects = new ObservableCollection<RegisteredSubject>();
        }
        public Term(List<RegisteredSubject> registeredSubjects)
        {
            this.registeredSubjects = new ObservableCollection<RegisteredSubject>(registeredSubjects);
        }

        public bool RegisterSubject(RegisteredSubject registeredSubject)
        {
            if (isActive)
            {
                registeredSubjects.Add(registeredSubject);
                return true;
            }

            return false;
        }
    }
}
