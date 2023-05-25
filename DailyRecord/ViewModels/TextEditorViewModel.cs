using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DailyRecord.ViewModels
{
    public class TextEditorViewModel : ViewModelBase
    {
        #region 프로퍼티
        private ObservableCollection<FontFamily> _fontFamilies;
        public ObservableCollection<FontFamily> FontFamilies
        {
            get => _fontFamilies;
            set => SetProperty(ref _fontFamilies, value);
        }

        private FontFamily _selectedFontFamily;
        public FontFamily SelectedFontFamily
        {
            get => _selectedFontFamily;
            set => SetProperty(ref _selectedFontFamily, value);
        }

        private ObservableCollection<double> _fontSizes;
        public ObservableCollection<double> FontSizes
        {
            get => _fontSizes;
            set => SetProperty(ref _fontSizes, value);
        }

        private double _selectedFontSize;
        public double SelectedFontSize
        {
            get => _selectedFontSize;
            set => SetProperty(ref _selectedFontSize, value);
        }
        #endregion

        public TextEditorViewModel()
        {
            FontFamilies = new ObservableCollection<FontFamily>(Fonts.SystemFontFamilies);
            FontSizes = new ObservableCollection<double>() 
            { 
                8.0d, 9.0d, 10.0d, 11.0d, 12.0d, 14.0d, 16.0d, 18.0d, 20.0d, 22.0d, 24.0d, 26.0d, 28.0d, 36.0d, 48.0d, 72.0d 
            };

            SelectedFontFamily = FontFamilies[0];
            SelectedFontSize = FontSizes[4];
        }
    }
}
