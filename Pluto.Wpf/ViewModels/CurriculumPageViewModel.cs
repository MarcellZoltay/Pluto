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

        public ObservableCollection<Subject> Subjects { get; private set; }

        public int SelectedSubjectIndex { get; set; }


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

            Subjects = new ObservableCollection<Subject>(_subjectService.GetSubjects());
            
            SelectedSubjectIndex = -1;


            NewSubjectCommand = new RelayCommand(NewSubjectOnClick);
            EditSubjectCommand = new RelayCommand(EditSubjectOnClick, p => SelectedSubjectIndex > -1);
            DeleteSubjectCommand = new RelayCommand(DeleteSubjectOnClick, p => SelectedSubjectIndex > -1);
            OrderListCommand = new RelayCommand(OrderListOnClick);
            RegisterSubjectCommand = new RelayCommand(RegisterSubjectOnClick, p => SelectedSubjectIndex > -1);
            UnregisterSubjectCommand = new RelayCommand(UnregisterSubjectOnClick, p => SelectedSubjectIndex > -1);
        }

        
        private void NewSubjectOnClick(object obj)
        {
            var dialogViewModel = new CreateOrEditSubjectDialogViewModel();
            if(dialogViewModel.ShowDialog() == true)
            {
                var subject = dialogViewModel.Subject;

                _subjectService.AddSubject(subject);
                var id = subject.SubjectId;
                Subjects.Add(_subjectService.GetSubjectById(id));               
            }
        }
        private void EditSubjectOnClick(object obj)
        {
            var subject = Subjects.ElementAt(SelectedSubjectIndex);

            var dialogViewModel = new CreateOrEditSubjectDialogViewModel(subject);
            if (dialogViewModel.ShowDialog() == true)
            {
                _subjectService.UpdateSubject(subject);

                var subjectList = new ObservableCollection<Subject>(_subjectService.GetSubjects());
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
            var subjects = new ObservableCollection<Subject>(Subjects.OrderBy(s => s.Name));

            Subjects.Clear();
            Subjects.AddRange(subjects);
        }
        private void RegisterSubjectOnClick(object obj)
        {
            var subject = Subjects.ElementAt(SelectedSubjectIndex);

            if (subject.IsRegistered)
            {
                MessageBox.Show("This subject is already registered", "Register subject", MessageBoxButton.OK);
            }
            else
            {
                var activeTerms = _termService.GetTerms(t => t.IsActive);
                var dialogViewModel = new RegisterSubjectDialogViewModel(subject.Name, activeTerms);
                if (dialogViewModel.ShowDialog() == true)
                {
                    var selectedTerm = dialogViewModel.SelectedTerm;

                    // TODO: RegisterSubject implementalasa, subject.IsRegistered beallitasa, lista frissit?, navigation property-k
                    _subjectRegistrationService.RegisterSubject(subject, selectedTerm);
                }
            }

            SelectedSubjectIndex = -1;
        }
        private void UnregisterSubjectOnClick(object obj)
        {


            MessageBox.Show("Do you want to unregister this subject?", "Register subject", MessageBoxButton.OKCancel, MessageBoxImage.Question);

            SelectedSubjectIndex = -1;
        }

    }
}
