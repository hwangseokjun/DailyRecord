using DailyRecord.Business;
using DailyRecord.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DailyRecord.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        private readonly IDataService _service;

        public MainWindowViewModel(IDataService service)
        {
            _service = service;
            TESTCommand = new RelayCommand(ExecuteTEST, CanExecuteTEST);
        }

        public ICommand TESTCommand { get; private set; }
        private void ExecuteTEST(object parameter)
        {
            
        }

        private bool CanExecuteTEST(object parameter)
        {
            // 실행 가능한지 여부를 결정하는 로직을 구현합니다.
            return true;
        }
    }
}
