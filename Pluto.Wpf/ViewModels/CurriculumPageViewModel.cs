using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Pluto.BLL.Model;
using Pluto.BLL.Services;
using Pluto.Wpf.ViewModels.Dialogs;
using Pluto.Wpf.Command;
using System.Windows;
using System.Threading.Tasks;

namespace Pluto.Wpf.ViewModels
{
    public class CurriculumPageViewModel : BindableBase
    {
        private string _title = "Curriculum Page";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private ObservableCollection<Subject> subjects;
        public ObservableCollection<Subject> Subjects
        {
            get { return subjects; }
            set { SetProperty(ref subjects, value); }
        }

        public int SelectedSubjectIndex { get; set; }

        private bool _isLoading = true;
        public bool IsLoading
        {
            get { return _isLoading; }
            set { SetProperty(ref _isLoading, value); }
        }

        private ISubjectService _subjectService;
        private ITermService _termService;
        private ISubjectRegistrationService _subjectRegistrationService;

        public RelayCommand NewSubjectCommand { get; private set; }
        public RelayCommand EditSubjectCommand { get; private set; }
        public RelayCommand DeleteSubjectCommand { get; private set; }
        public RelayCommand OrderListCommand { get; private set; }
        public RelayCommand RegisterSubjectCommand { get; private set; }
        public RelayCommand UnregisterSubjectCommand { get; private set; }

        public CurriculumPageViewModel(ISubjectService subjectService,
                                       ITermService termService,
                                       ISubjectRegistrationService subjectRegistrationService)
        {
            _subjectService = subjectService;
            _termService = termService;
            _subjectRegistrationService = subjectRegistrationService;

            NewSubjectCommand = new RelayCommand(NewSubjectOnClick);
            EditSubjectCommand = new RelayCommand(EditSubjectOnClick, p => SelectedSubjectIndex > -1);
            DeleteSubjectCommand = new RelayCommand(DeleteSubjectOnClick, p => SelectedSubjectIndex > -1);
            OrderListCommand = new RelayCommand(OrderListOnClick);
            RegisterSubjectCommand = new RelayCommand(RegisterSubjectOnClick, p => SelectedSubjectIndex > -1);
            UnregisterSubjectCommand = new RelayCommand(UnregisterSubjectOnClick, p => SelectedSubjectIndex > -1);

            SelectedSubjectIndex = -1;

            Task.Factory.StartNew( async () => {
                List<Subject> subjects = await _subjectService.GetSubjects();
                Subjects = new ObservableCollection<Subject>();
                Subjects.AddRange(subjects);
                
                IsLoading = false;
            });
        }

        
        private void NewSubjectOnClick(object obj)
        {
            var dialogViewModel = new CreateOrEditSubjectDialogViewModel();
            if(dialogViewModel.ShowDialog() == true)
            {
                var subject = dialogViewModel.Subject;

                _subjectService.AddSubject(subject);             
                Subjects.Add(subject);
            }
        }
        private void EditSubjectOnClick(object obj)
        {
            var subject = Subjects.ElementAt(SelectedSubjectIndex);

            var dialogViewModel = new CreateOrEditSubjectDialogViewModel(subject);
            if (dialogViewModel.ShowDialog() == true)
            {
                _subjectService.UpdateSubject(subject);
            }

            SelectedSubjectIndex = -1;
        }
        private void DeleteSubjectOnClick(object obj)
        {
            var subject = Subjects.ElementAt(SelectedSubjectIndex);

            var result = MessageBox.Show("Are you sure you want to delete " + subject.Name, "Delete subject", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK)
            {
                _subjectService.DeleteSubjectById(subject.SubjectId);
                Subjects.Remove(subject);
            }
        }
        private void OrderListOnClick(object obj)
        {
            var subjects = new List<Subject>(Subjects.OrderBy(s => s.Name));
        
            Subjects.Clear();
            Subjects.AddRange(subjects);
        }
        private async void RegisterSubjectOnClick(object obj)
        {
            var subject = Subjects.ElementAt(SelectedSubjectIndex);

            if (subject.IsRegistered)
            {
                MessageBox.Show("This subject is already registered", "Register subject", MessageBoxButton.OK);
            }
            else
            {
                var activeTerms = await _termService.GetTerms(t => t.IsActive);
                var dialogViewModel = new RegisterSubjectDialogViewModel(subject.Name, activeTerms);
                if (dialogViewModel.ShowDialog() == true)
                {
                    var selectedTerm = dialogViewModel.SelectedTerm;

                    _subjectRegistrationService.RegisterSubject(subject, selectedTerm);
                }
            }

            SelectedSubjectIndex = -1;
        }
        private void UnregisterSubjectOnClick(object obj)
        {
            var subject = Subjects.ElementAt(SelectedSubjectIndex);

            if (!subject.IsRegistered)
            {
                MessageBox.Show("This subject is unregistered", "Unregister subject", MessageBoxButton.OK);
            }
            else
            {
                var result = MessageBox.Show("Do you want to unregister this subject?", "Unregister subject", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if(result == MessageBoxResult.OK)
                {
                    _subjectRegistrationService.UnregisterSubject(subject);
                }
            }

            SelectedSubjectIndex = -1;
        }

    }
}
