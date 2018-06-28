using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pluto.BLL.DAL;
using Pluto.BLL.Model;

namespace Pluto.BLL.Services
{
    public class SubjectService : ISubjectService
    {
        public List<Subject> GetSubjects()
        {
            List<Subject> subjects;

            using (var context = new PlutoContext())
            {
                subjects = context.Subjects.ToList();
            }

            return subjects;
        }
    }
}
