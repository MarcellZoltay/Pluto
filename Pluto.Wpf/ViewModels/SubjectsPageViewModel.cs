using Pluto.BLL.Model;
using Pluto.BLL.Services;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

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

        private ObservableCollection<Term> terms;
        public ObservableCollection<Term> Terms
        {
            get { return terms; }
            set { SetProperty(ref terms, value); }
        }

        private ITermService _termService;

        public SubjectsPageViewModel(ITermService termService)
        {
            _termService = termService;

            Task.Factory.StartNew(async () => {
                List<Term> terms = await _termService.GetTerms();
                Terms = new ObservableCollection<Term>(terms);
            });
        }
    }
}
