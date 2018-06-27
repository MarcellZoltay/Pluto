﻿using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pluto.Wpf.Views
{
    /// <summary>
    /// Interaction logic for NavigationBar.xaml
    /// </summary>
    public partial class NavigationBar : UserControl
    {
        public DelegateCommand StartPageCommand
        {
            get { return (DelegateCommand)GetValue(NavigationBar.StartPageCommandProperty); }
            set { SetValue(NavigationBar.StartPageCommandProperty, value); }
        }
        public static readonly DependencyProperty StartPageCommandProperty = DependencyProperty.Register(
            nameof(StartPageCommand),
            typeof(DelegateCommand),
            typeof(NavigationBar));

        public DelegateCommand CurriculumPageCommand
        {
            get { return (DelegateCommand)GetValue(NavigationBar.CurriculumPageCommandProperty); }
            set { SetValue(NavigationBar.CurriculumPageCommandProperty, value); }
        }
        public static readonly DependencyProperty CurriculumPageCommandProperty = DependencyProperty.Register(
            nameof(CurriculumPageCommand),
            typeof(DelegateCommand),
            typeof(NavigationBar));

        public NavigationBar()
        {
            InitializeComponent();
        }
    }
}