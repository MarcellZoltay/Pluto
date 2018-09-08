using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluto.BLL.Model.RegisteredSubjects
{
    public class RegisteredSubject : MyBindableBase
    {
        private int registeredSubjectId;
        public int RegisteredSubjectId
        {
            get { return registeredSubjectId; }
            set { SetProperty(ref registeredSubjectId, value); }
        }

        private int subjectId;
        public int SubjectId
        {
            get { return subjectId; }
            set { SetProperty(ref subjectId, value); }
        }

        private int termId;
        public int TermId
        {
            get { return termId; }
            set { SetProperty(ref termId, value); }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private int credit;
        public int Credit
        {
            get { return credit; }
            set { SetProperty(ref credit, value); }
        }

    }
}
