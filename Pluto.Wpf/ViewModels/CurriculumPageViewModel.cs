using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Pluto.BLL.Model;
using Pluto.BLL.Services;

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

        private ISubjectService _subjectService;

        public CurriculumPageViewModel(ISubjectService subjectService)
        {
            _subjectService = subjectService;

            Subjects = new ObservableCollection<Subject>(_subjectService.GetSubjects());
        }
    }
}
