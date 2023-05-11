using DailyRecord.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace DailyRecord.ViewModels
{
    class TextEditorUserControlViewModel : INotifyPropertyChanged
    {
        #region 프로퍼티
        private string _text;
        public string Text
        {
            get => _text;
            set
            {
                if (_text != value)
                {
                    _text = value;
                    OnPropertyChanged(nameof(Text));
                }
            }
        }

        private ObservableCollection<FontFamily> _fontFamilies;
        public ObservableCollection<FontFamily> FontFamilies
        {
            get => _fontFamilies;
            set
            {
                if (_fontFamilies != value)
                {
                    _fontFamilies = value;
                    OnPropertyChanged(nameof(FontFamilies));
                }
            }
        }

        private FontFamily _fontFamily;
        public FontFamily FontFamily
        {
            get => _fontFamily;
            set
            {
                if (_fontFamily != value)
                {
                    _fontFamily = value;
                    OnPropertyChanged(nameof(FontFamily));
                }
            }
        }

        private ObservableCollection<double> _fontSizes;
        public ObservableCollection<double> FontSizes
        {
            get => _fontSizes;
            set
            {
                if (_fontSizes != value)
                {
                    _fontSizes = value;
                    OnPropertyChanged(nameof(FontSizes));
                }
            }
        }

        private double _fontSize;
        public double FontSize
        {
            get => _fontSize;
            set
            {
                if (_fontSize != value)
                {
                    _fontSize = value;
                    OnPropertyChanged(nameof(FontSize));
                }
            }
        }
        #endregion

        public TextEditorUserControlViewModel()
        {
            FontFamilies = new ObservableCollection<FontFamily>(Fonts.SystemFontFamilies);
            FontFamily = FontFamilies.FirstOrDefault();
            FontSizes = new ObservableCollection<double>(Constants.FONT_SIZES);
            FontSize = FontSizes[3];
            BoldCommand = new RelayCommand(ExecuteBold);
            ItalicCommand = new RelayCommand(ExecuteItalic);
            UnderlineCommand = new RelayCommand(ExecuteUnderline);
            StrikeCommand = new RelayCommand(ExecuteStrike);
            DecreaseFontCommand = new RelayCommand(ExecuteDecreaseFont);
            IncreaseFontCommand = new RelayCommand(ExecuteIncreaseFont);
            FontColorCommand = new RelayCommand(ExecuteFontColor);
            HighlightTextCommand = new RelayCommand(ExecuteHighlightText);
            ApplyFontFamilyCommand = new RelayCommand(ExecuteApplyFontFamily);
            ApplyFontSizeCommand = new RelayCommand(ExecuteApplyFontSize);
            AlignJustifyCommand = new RelayCommand(ExecuteAlignJustify);
            AlignLeftCommand = new RelayCommand(ExecuteAlignLeft);
            AlignCenterCommand = new RelayCommand(ExecuteAlignCenter);
            AlignRightCommand = new RelayCommand(ExecuteAlignRight);
            TextChangedCommand = new RelayCommand(ExecuteTextChanged);
        }

        #region 커맨드
        public ICommand BoldCommand { get; private set; }
        private void ExecuteBold(object parameter)
        {
            if (parameter is RichTextBox richTextBox) 
            {
                EditingCommands.ToggleBold.Execute(null, richTextBox);
                richTextBox.Focus();
            }
        }

        public ICommand ItalicCommand { get; private set; }
        private void ExecuteItalic(object parameter)
        {
            if (parameter is RichTextBox richTextBox)
            {
                EditingCommands.ToggleItalic.Execute(null, richTextBox);
                richTextBox.Focus();
            }
        }

        public ICommand UnderlineCommand { get; private set; }
        private void ExecuteUnderline(object parameter)
        {
            if (parameter is RichTextBox richTextBox)
            {
                EditingCommands.ToggleUnderline.Execute(null, richTextBox);
                richTextBox.Focus();
            }
        }

        public ICommand StrikeCommand { get; private set; }
        private void ExecuteStrike(object parameter)
        {
            // 실행할 로직을 구현합니다.
        }

        public ICommand DecreaseFontCommand { get; private set; }
        private void ExecuteDecreaseFont(object parameter)
        {
            if (parameter is RichTextBox richTextBox)
            {
                EditingCommands.DecreaseFontSize.Execute(null, richTextBox);
                richTextBox.Focus();
            }
        }

        public ICommand IncreaseFontCommand { get; private set; }
        private void ExecuteIncreaseFont(object parameter)
        {
            if (parameter is RichTextBox richTextBox)
            {
                EditingCommands.IncreaseFontSize.Execute(null, richTextBox);
                richTextBox.Focus();
            }
        }

        public ICommand FontColorCommand { get; private set; }
        private void ExecuteFontColor(object parameter)
        {
        }

        public ICommand HighlightTextCommand { get; private set; }
        private void ExecuteHighlightText(object parameter)
        {
            // 실행할 로직을 구현합니다.
        }

        public ICommand AlignJustifyCommand { get; private set; }
        private void ExecuteAlignJustify(object parameter)
        {
            if (parameter is RichTextBox richTextBox)
            {
                EditingCommands.AlignJustify.Execute(null, richTextBox);
                richTextBox.Focus();
            }
        }

        public ICommand AlignLeftCommand { get; private set; }
        private void ExecuteAlignLeft(object parameter)
        {
            if (parameter is RichTextBox richTextBox)
            {
                EditingCommands.AlignLeft.Execute(null, richTextBox);
                richTextBox.Focus();
            }
        }

        public ICommand AlignCenterCommand { get; private set; }
        private void ExecuteAlignCenter(object parameter)
        {
            if (parameter is RichTextBox richTextBox)
            {
                EditingCommands.AlignCenter.Execute(null, richTextBox);
                richTextBox.Focus();
            }
        }

        public ICommand AlignRightCommand { get; private set; }
        private void ExecuteAlignRight(object parameter)
        {
            if (parameter is RichTextBox richTextBox)
            {
                EditingCommands.AlignRight.Execute(null, richTextBox);
                richTextBox.Focus();
            }
        }

        public ICommand ApplyFontFamilyCommand { get; private set; }
        private void ExecuteApplyFontFamily(object parameter)
        {
            if (parameter is RichTextBox richTextBox)
            {
                TextSelection selection = richTextBox.Selection;

                if (selection.IsEmpty)
                {
                    richTextBox.Focus();
                    return;
                }

                selection.ApplyPropertyValue(TextElement.FontFamilyProperty, FontFamily);
                richTextBox.Focus();
            }
        }

        public ICommand ApplyFontSizeCommand { get; private set; }
        private void ExecuteApplyFontSize(object parameter)
        {
            if (parameter is RichTextBox richTextBox) 
            {
                TextSelection selection = richTextBox.Selection;

                if (selection.IsEmpty) 
                {
                    richTextBox.Focus();
                    return;
                }

                selection.ApplyPropertyValue(TextElement.FontSizeProperty, FontSize);
            }
        }

        public ICommand TextChangedCommand { get; private set; }
        private void ExecuteTextChanged(object parameter)
        {
            if (parameter is RichTextBox richTextBox)
            {
                richTextBox.Selection.ApplyPropertyValue(TextElement.FontFamilyProperty, FontFamily);
                richTextBox.Selection.ApplyPropertyValue(TextElement.FontSizeProperty, FontSize);
            }
        }

        public ICommand ImageUploadCommand { get; private set; }
        private void ExecuteImageUpload(object parameter)
        {
            // 실행할 로직을 구현합니다.
        }

        public ICommand CreateGridCommand { get; private set; }
        private void ExecuteCreateGrid(object parameter)
        {
            // 실행할 로직을 구현합니다.
        }

        public ICommand HyperLinkCommand { get; private set; }
        private void ExecuteHyperLink(object parameter)
        {
            // 실행할 로직을 구현합니다.
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
