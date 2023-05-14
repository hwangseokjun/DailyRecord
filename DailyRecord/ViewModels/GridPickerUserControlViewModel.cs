using DailyRecord.Commands;
using DailyRecord.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DailyRecord.ViewModels
{
    public class GridPickerUserControlViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<GridButton> GridButtons { get; } =
            new ObservableCollection<GridButton>(
                from row in Enumerable.Range(1, 9)
                from column in Enumerable.Range(1, 10)
                select new GridButton { Tag = $"Button({row},{column})", Row = row, Column = column });

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
