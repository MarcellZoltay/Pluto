using Pluto.BLL.Model;
using Pluto.BLL.Model.RegisteredSubjects;
using Pluto.BLL.Services.Interfaces;
using Pluto.DAL;
using Pluto.DAL.Entities.RegisteredSubjectEntities;
using Pluto.DAL.Entities.SubjectEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluto.BLL.Services
{
    public class RegisteredSubjectService : IRegisteredSubjectService
    {
        public event EventHandler RegisteredSubjectsChanged;

        public async Task<List<RegisteredSubject>> GetRegisteredSubjectsAsync()
        {
            return await Task.Factory.StartNew(() => Model.DataManager.Instance.GetRegisteredSubjects());
        }

        public async Task RegisterSubjectAsync(Subject subject, Term selectedTerm)
        {
            var registeredSubject = subject.Register();

            var result = selectedTerm.RegisterSubject(registeredSubject);

            if (result)
            {
                await Task.Factory.StartNew(() => Model.DataManager.Instance.AddRegisteredSubject(registeredSubject));
                await Task.Factory.StartNew(() => Model.DataManager.Instance.UpdateSubject(subject));

                RegisteredSubjectsChanged?.Invoke(this, null);
            }
            else
            {
                subject.RollbackRegistration(registeredSubject);
            }
        }

        public async Task<bool> UnregisterSubjectAsync(Subject subject)
        {
            var actualRegsiteredSubject = subject.ActualRegisteredSubject;
            var result = subject.Unregister();

            if (result)
            {
                await Task.Factory.StartNew(() => Model.DataManager.Instance.DeleteRegisteredSubject(actualRegsiteredSubject));
                await Task.Factory.StartNew(() => Model.DataManager.Instance.UpdateSubject(subject));

                RegisteredSubjectsChanged?.Invoke(this, null);

                return true;
            }
            
            return false;
        }
        
    }
}
