using Pluto.BLL.Model.RegisteredSubjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            set { SetProperty(ref isRegistered, value); }
        }

        private List<RegisteredSubject> registeredSubjects;
        public List<RegisteredSubject> RegisteredSubjects
        {
            get { return registeredSubjects; }
        }

        public Subject()
        {
            registeredSubjects = new List<RegisteredSubject>();
        }

        public void SetRegisteredSubject(RegisteredSubject registeredSubject)
        {
            registeredSubject.SubjectId = SubjectId;
            registeredSubject.Name = Name;
            registeredSubject.Credit = Credit;
        }
        public void Register(RegisteredSubject registeredSubject)
        {
            registeredSubjects.Add(registeredSubject);
        }
        public void Unregister(RegisteredSubject registeredSubject)
        {
            registeredSubjects.Remove(registeredSubject);

            if(registeredSubjects.Count == 0)
                IsRegistered = false;
        }
    }
}
