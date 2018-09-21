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
            private set { SetProperty(ref subjectId, value); }
        }

        private int termId;
        public int TermId
        {
            get { return termId; }
            private set { SetProperty(ref termId, value); }
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

        private bool isClosed;
        public bool IsClosed
        {
            get { return isClosed; }
            private set { SetProperty(ref isClosed, value); }
        }

        private Subject subject;
        public Subject Subject
        {
            get { return subject; }
            private set
            {
                SetProperty(ref subject, value);
                subjectId = value.SubjectId;
            }
        }
        private Term term;
        public Term Term
        {
            get { return term; }
            set
            {
                SetProperty(ref term, value);
                termId = value.TermId;
            }
        }

        public RegisteredSubject() { }
        public RegisteredSubject(Subject subject)
        {
            Subject = subject;
            Name = subject.Name;
            Credit = subject.Credit;
        }

        public void Close()
        {
            Subject.IsRegistered = false;
            IsClosed = true;
        }
        public bool Unregister()
        {
            if(!IsClosed)
                return term.UnregisterSubject(this);

            return false;
        }

        public void Load(int subjectId, int termId, bool isClosed)
        {
            SubjectId = subjectId;
            TermId = termId;
            IsClosed = isClosed;
        }
        public void SetAssociations(Subject subject, Term term)
        {
            Subject = subject;
            Term = term;
        }
    }
}
