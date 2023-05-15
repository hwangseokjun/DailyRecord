﻿using DailyRecord.DataAccess;
using DailyRecord.DataModels;
using DailyRecord.ViewModels;
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

namespace DailyRecord.UserControls
{
    /// <summary>
    /// TreeUserControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TreeUserControl : UserControl
    {
        public TreeUserControl()
        {
            InitializeComponent();
            DataContext = new YearMonthItemViewModel((MockRepository)App.Current.Services.GetService(typeof(IRepository)));
        }
    }
}
