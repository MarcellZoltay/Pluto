using Pluto.BLL.Model;
using Pluto.BLL.Model.RegisteredSubjects;
using Pluto.BLL.Services;
using Pluto.BLL.Services.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Pluto.Wpf.ViewModels
{
    public class SubjectsPageViewModel : BindableBase
    {
        private string _title = "Subjects page";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private bool _isLoading = true;
        public bool IsLoading
        {
            get { return _isLoading; }
            set { SetProperty(ref _isLoading, value); }
        }

        private ObservableCollection<RegisteredSubject> registeredSubjects;
        public ObservableCollection<RegisteredSubject> RegisteredSubjects
        {
            get { return registeredSubjects; }
            set { SetProperty(ref registeredSubjects, value); }
        }

        private IRegisteredSubjectService _registeredSubjectService;

        public SubjectsPageViewModel(IRegisteredSubjectService regsiteredSubjectService)
        {
            
            _registeredSubjectService = regsiteredSubjectService;
            _registeredSubjectService.RegisteredSubjectsChanged += _registeredSubjectService_RegisteredSubjectsChanged; ;

            RegisteredSubjects = new ObservableCollection<RegisteredSubject>();

            var currentDispatcher = Dispatcher.CurrentDispatcher;
            Task.Factory.StartNew( async () =>
            {
                List<RegisteredSubject> registeredSubjects = await _registeredSubjectService.GetRegisteredSubjectsAsync();
                registeredSubjects = new List<RegisteredSubject>(registeredSubjects.OrderBy(s => s.Term.Name));

                currentDispatcher.Invoke(new Action(() =>
                {
                    RegisteredSubjects.AddRange(registeredSubjects);

                    IsLoading = false;
                }));
            });
        }

        private async void _registeredSubjectService_RegisteredSubjectsChanged(object sender, EventArgs e)
        {
            var currentDispatcher = Dispatcher.CurrentDispatcher;
            await Task.Factory.StartNew(async () =>
            {
                List<RegisteredSubject> registeredSubjects = await _registeredSubjectService.GetRegisteredSubjectsAsync();
                registeredSubjects = new List<RegisteredSubject>(registeredSubjects.OrderBy(s => s.Term.Name));

                currentDispatcher.Invoke(new Action(() =>
                {
                    RegisteredSubjects.Clear();
                    RegisteredSubjects.AddRange(registeredSubjects);
                }));
            });
        }
    }
}
