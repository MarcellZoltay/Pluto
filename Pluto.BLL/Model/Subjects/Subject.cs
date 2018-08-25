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
    }
}
