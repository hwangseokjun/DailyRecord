using DailyRecord.Commands;
using DailyRecord.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DailyRecord.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public RegisterViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            ToDiaryCommand = new RelayCommand(ExecuteToDiary);
        }

        public ICommand ToDiaryCommand { get; private set; }
        private void ExecuteToDiary(object parameter)
        {
            _navigationService.Navigate(NavigationType.Diary);
        }
    }
}
