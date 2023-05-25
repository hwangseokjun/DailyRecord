using DailyRecord.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyRecord.Stores
{
    public class MainNavigationStore : ViewModelBase
    {
        private INotifyPropertyChanged _currentViewModel;
        public INotifyPropertyChanged CurrentViewModel
        {
            get => _currentViewModel;
            set 
            {
                _currentViewModel = value;
                CurrentViewModelChanged?.Invoke();
                _currentViewModel = null;
            }
        }

        public Action CurrentViewModelChanged { get; set; }
    }
}
