using Pluto.BLL.Model;
using Pluto.BLL.Services;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
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

        private ObservableCollection<Term> terms;
        public ObservableCollection<Term> Terms
        {
            get { return terms; }
            set { SetProperty(ref terms, value); }
        }

        private bool _isLoading = true;
        public bool IsLoading
        {
            get { return _isLoading; }
            set { SetProperty(ref _isLoading, value); }
        }

        private ITermService _termService;

        public SubjectsPageViewModel(ITermService termService)
        {
            _termService = termService;
            _termService.TermsChanged += _termService_TermsChanged;

            Terms = new ObservableCollection<Term>();

            //Task.Factory.StartNew(async () => {
            //    List<Term> terms = await _termService.GetTermsAsync();
            //    Terms.AddRange(terms);
            //});

            Dispatcher.CurrentDispatcher.InvokeAsync(new Action(async () =>
            {
                List<Term> terms = await _termService.GetTermsAsync();
                Terms.AddRange(terms);

                IsLoading = false;
            }));
        }

        private async void _termService_TermsChanged(object sender, EventArgs e)
        {
            List<Term> terms = await _termService.GetTermsAsync();
            Terms.Clear();
            Terms.AddRange(terms);
        }
    }
}
