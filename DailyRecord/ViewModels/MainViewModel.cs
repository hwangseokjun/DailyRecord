using DailyRecord.Commands;
using DailyRecord.Services;
using DailyRecord.Stores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DailyRecord.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly MainNavigationStore _mainNavigationStore;
        private readonly INavigationService _navigationService;

        #region 프로퍼티
        private INotifyPropertyChanged _currentViewModel;
        public INotifyPropertyChanged CurrentViewModel
        {
            get => _currentViewModel;
            set => SetProperty(ref _currentViewModel, value);
        }
        #endregion

        public MainViewModel(MainNavigationStore mainNavigationStore, INavigationService navigationService)
        {
            _mainNavigationStore = mainNavigationStore;
            _mainNavigationStore.CurrentViewModelChanged += CurrentViewModelChanged;
            _navigationService = navigationService;
            _navigationService.Navigate(NavigationType.Diary);
            ToDiaryCommand = new RelayCommand(ExecuteToDiary);
            ToRegisterCommand = new RelayCommand(ExecuteToRegister);
            ToStatisticsCommand = new RelayCommand(ExecuteToStatistics);
            ToTasksCommand = new RelayCommand(ExecuteToTasks);
        }

        #region 커맨드
        public ICommand ToDiaryCommand { get; private set; }
        private void ExecuteToDiary(object parameter)
        {
            _navigationService.Navigate(NavigationType.Diary);
        }

        public ICommand ToRegisterCommand { get; private set; }
        private void ExecuteToRegister(object parameter)
        {
            _navigationService.Navigate(NavigationType.Register);
        }

        public ICommand ToStatisticsCommand { get; private set; }
        private void ExecuteToStatistics(object parameter)
        {
            _navigationService.Navigate(NavigationType.Statistics);
        }

        public ICommand ToTasksCommand { get; private set; }
        private void ExecuteToTasks(object parameter)
        {
            _navigationService.Navigate(NavigationType.Tasks);
        }
        #endregion

        private void CurrentViewModelChanged() 
        {
            CurrentViewModel = _mainNavigationStore.CurrentViewModel;
        }
    }
}
