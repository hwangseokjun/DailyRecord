using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace DailyRecord.ViewModels
{
    public class ColorPickerUserControlViewModel : INotifyPropertyChanged
    {
        private Color color;
        public Color Color
        {
            get => color;
            set
            {
                if (color != value)
                {
                    color = value;
                    OnPropertyChanged(nameof(Color));
                }
            }
        }

        public ICommand SelectColorCommand { get; private set; }
        private void ExecuteSelectColor(object parameter)
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
