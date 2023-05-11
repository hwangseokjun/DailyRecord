using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DailyRecord.ViewModels
{
    public class TreeUserControlViewModel : INotifyPropertyChanged
    {
        public TreeUserControlViewModel()
        {

        }

        public ICommand DateCommand { get; private set; }
        private void ExecuteDefault(object parameter)
        {
            // 실행할 로직을 구현합니다.
        }

        public ICommand CategoryCommand { get; private set; }
        private void ExecuteCategory(object parameter)
        {
            // 실행할 로직을 구현합니다.
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
