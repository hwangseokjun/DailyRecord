using DailyRecord.Stores;
using DailyRecord.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyRecord.Services
{
    public class NavigationService : INavigationService
    {
        private readonly MainNavigationStore _mainNavigationStore;
        private INotifyPropertyChanged CurrentViewModel 
        {
            set => _mainNavigationStore.CurrentViewModel = value;
        }

        public NavigationService(MainNavigationStore mainNavigationStore)
        {
            _mainNavigationStore = mainNavigationStore;
        }

        public void Navigate(NavigationType navigationType)
        {
            switch (navigationType)
            {
                case NavigationType.Diary:
                    CurrentViewModel = App.Current.Services.GetService(typeof(DiaryViewModel)) as ViewModelBase;
                    break;
                case NavigationType.Register:
                    CurrentViewModel = App.Current.Services.GetService(typeof(RegisterViewModel)) as ViewModelBase;
                    break;
                case NavigationType.Statistics:
                    CurrentViewModel = App.Current.Services.GetService(typeof(StatisticsViewModel)) as ViewModelBase;
                    break;
                case NavigationType.Tasks:
                    CurrentViewModel = App.Current.Services.GetService(typeof(TasksViewModel)) as ViewModelBase;
                    break;
                default:
                    return;
            }
        }
    }
}
