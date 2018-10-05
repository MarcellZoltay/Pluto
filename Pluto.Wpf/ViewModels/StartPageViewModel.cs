using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pluto.Wpf.ViewModels
{
    public class StartPageViewModel : BindableBase
    {
        private string _title = "Start page";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public StartPageViewModel()
        {

        }
    }
}
