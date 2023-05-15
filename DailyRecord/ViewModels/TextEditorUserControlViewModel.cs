using DailyRecord.Commands;
using DailyRecord.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DailyRecord.ViewModels
{
    public class TextEditorUserControlViewModel : ViewModelBase
    {
        private RichTextBox _richTextBox;

        #region 프로퍼티
        private bool _isBold;
        public bool IsBold
        {
            get => _isBold;
            set
            {
                if (_isBold != value)
                {
                    _isBold = value;
                    OnPropertyChanged(nameof(IsBold));
                }
            }
        }

        private bool _isItalic;
        public bool IsItalic
        {
            get => _isItalic;
            set
            {
                if (_isItalic != value)
                {
                    _isItalic = value;
                    OnPropertyChanged(nameof(IsItalic));
                }
            }
        }

        private bool _isUnderline;
        public bool IsUnderline
        {
            get => _isUnderline;
            set
            {
                if (_isUnderline != value)
                {
                    _isUnderline = value;
                    OnPropertyChanged(nameof(IsUnderline));
                }
            }
        }

        private bool _isStrike;
        public bool IsStrike
        {
            get => _isStrike;
            set
            {
                if (_isStrike != value)
                {
                    _isStrike = value;
                    OnPropertyChanged(nameof(IsStrike));
                }
            }
        }

        private bool _isGridChecked;
        public bool IsGridChecked
        {
            get => _isGridChecked;
            set
            {
                if (_isGridChecked != value)
                {
                    _isGridChecked = value;
                    OnPropertyChanged(nameof(IsGridChecked));
                }
            }
        }

        private bool _isColorChecked;
        public bool IsColorChecked
        {
            get => _isColorChecked;
            set
            {
                if (_isColorChecked != value)
                {
                    _isColorChecked = value;
                    OnPropertyChanged(nameof(IsColorChecked));
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

        private Brush _fontColor;
        public Brush FontColor
        {
            get => _fontColor;
            set
            {
                if (_fontColor != value)
                {
                    _fontColor = value;
                    OnPropertyChanged(nameof(FontColor));
                }
            }
        }
        #endregion

        public TextEditorUserControlViewModel(RichTextBox richTextBox)
        {
            _richTextBox = richTextBox;
            FontFamilies = new ObservableCollection<FontFamily>(Fonts.SystemFontFamilies);
            FontFamily = FontFamilies.FirstOrDefault();
            FontSizes = new ObservableCollection<double>(Constants.FONT_SIZES);
            FontSize = FontSizes[5];
            BoldCommand = new RelayCommand(ExecuteBold);
            ItalicCommand = new RelayCommand(ExecuteItalic);
            StrikeCommand = new RelayCommand(ExecuteStrike);
            DecreaseFontCommand = new RelayCommand(ExecuteDecreaseFont);
            IncreaseFontCommand = new RelayCommand(ExecuteIncreaseFont);
            ApplyFontFamilyCommand = new RelayCommand(ExecuteApplyFontFamily);
            ApplyFontSizeCommand = new RelayCommand(ExecuteApplyFontSize);
            AlignJustifyCommand = new RelayCommand(ExecuteAlignJustify);
            AlignLeftCommand = new RelayCommand(ExecuteAlignLeft);
            AlignCenterCommand = new RelayCommand(ExecuteAlignCenter);
            AlignRightCommand = new RelayCommand(ExecuteAlignRight);
            TextChangedCommand = new RelayCommand(ExecuteTextChanged);
            UploadImageCommand = new RelayCommand(ExecuteUploadImage);
            SelectColorCommand = new RelayCommand(ExecuteSelectColor);
            PressTabCommand = new RelayCommand(ExecutePressTab);
            SelectCellCommand = new RelayCommand(ExecuteSelectCell);
        }

        #region 커맨드
        public ICommand BoldCommand { get; private set; }
        private void ExecuteBold(object parameter)
        {
            if (IsBold)
            {
                _richTextBox.Selection.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);
            }
            else 
            {
                _richTextBox.Selection.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Regular);
            }
            _richTextBox.Focus();
        }

        public ICommand ItalicCommand { get; private set; }
        private void ExecuteItalic(object parameter)
        {
            if (IsItalic)
            {
                _richTextBox.Selection.ApplyPropertyValue(TextElement.FontStyleProperty, FontStyles.Italic);
            }
            else 
            {
                _richTextBox.Selection.ApplyPropertyValue(TextElement.FontStyleProperty, FontStyles.Normal);
            }
            _richTextBox.Focus();
        }

        public ICommand StrikeCommand { get; private set; }
        private void ExecuteStrike(object parameter)
        {
            if (IsStrike)
            {
                _richTextBox.Selection.ApplyPropertyValue(TextBlock.TextDecorationsProperty, TextDecorations.Strikethrough);
            }
            else
            {
                _richTextBox.Selection.ApplyPropertyValue(TextBlock.TextDecorationsProperty, null);
            }
            _richTextBox.Focus();
        }

        public ICommand DecreaseFontCommand { get; private set; }
        private void ExecuteDecreaseFont(object parameter)
        {
            EditingCommands.DecreaseFontSize.Execute(null, _richTextBox);
            _richTextBox.Focus();
        }

        public ICommand IncreaseFontCommand { get; private set; }
        private void ExecuteIncreaseFont(object parameter)
        {
            EditingCommands.IncreaseFontSize.Execute(null, _richTextBox);
            _richTextBox.Focus();
        }

        public ICommand AlignJustifyCommand { get; private set; }
        private void ExecuteAlignJustify(object parameter)
        {
            EditingCommands.AlignJustify.Execute(null, _richTextBox);
            _richTextBox.Focus();
        }

        public ICommand AlignLeftCommand { get; private set; }
        private void ExecuteAlignLeft(object parameter)
        {
            EditingCommands.AlignLeft.Execute(null, _richTextBox);
            _richTextBox.Focus();
        }

        public ICommand AlignCenterCommand { get; private set; }
        private void ExecuteAlignCenter(object parameter)
        {
            EditingCommands.AlignCenter.Execute(null, _richTextBox);
            _richTextBox.Focus();
        }

        public ICommand AlignRightCommand { get; private set; }
        private void ExecuteAlignRight(object parameter)
        {
            EditingCommands.AlignRight.Execute(null, _richTextBox);
            _richTextBox.Focus();
        }

        public ICommand ApplyFontFamilyCommand { get; private set; }
        private void ExecuteApplyFontFamily(object parameter)
        {
            TextSelection selection = _richTextBox.Selection;

            if (selection.IsEmpty)
            {
                _richTextBox.Focus();
                return;
            }

            selection.ApplyPropertyValue(TextElement.FontFamilyProperty, FontFamily);
            _richTextBox.Focus();
        }

        public ICommand ApplyFontSizeCommand { get; private set; }
        private void ExecuteApplyFontSize(object parameter)
        {
            TextSelection selection = _richTextBox.Selection;

            if (selection.IsEmpty)
            {
                _richTextBox.Focus();
                return;
            }

            selection.ApplyPropertyValue(TextElement.FontSizeProperty, FontSize);
        }

        public ICommand TextChangedCommand { get; private set; }
        private void ExecuteTextChanged(object parameter)
        {
            TextPointer pointer = _richTextBox.CaretPosition;

            if (pointer.GetPointerContext(LogicalDirection.Backward) == TextPointerContext.Text)
            {
                TextPointer stringStart = pointer.GetPositionAtOffset(-1, LogicalDirection.Backward);
                TextPointer stringEnd = pointer.GetPositionAtOffset(0, LogicalDirection.Forward);
                var range = new TextRange(stringStart, stringEnd);
                range.ApplyPropertyValue(TextElement.FontFamilyProperty, FontFamily);
                range.ApplyPropertyValue(TextElement.FontSizeProperty, FontSize);
            }
        }

        public ICommand UploadImageCommand { get; private set; }
        private void ExecuteUploadImage(object parameter)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "이미지파일(*.png;*.jpg;*.gif)|*.png;*.jpg;*.jpeg;*.gif";
            
            if (openFileDialog.ShowDialog() == false)
            {
                return;
            }

            using (var memoryStream = new MemoryStream())
            using (var fileStream = new FileStream(openFileDialog.FileName, FileMode.Open))
            {
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = fileStream;
                bitmapImage.EndInit();

                var encoder = new JpegBitmapEncoder();
                encoder.QualityLevel = 90;
                encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
                encoder.Save(memoryStream);

                while (memoryStream.Length > 300000)
                {
                    encoder.QualityLevel -= 10;
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    encoder.Save(memoryStream);

                    if (encoder.QualityLevel < 10)
                    {
                        return;
                    }
                }

                memoryStream.Seek(0, SeekOrigin.Begin);
                var compressedBitmapImage = new BitmapImage();
                compressedBitmapImage.BeginInit();
                compressedBitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                compressedBitmapImage.StreamSource = memoryStream;
                compressedBitmapImage.EndInit();

                var inlineUIContainer = new InlineUIContainer();
                inlineUIContainer.Child = new Image()
                {
                    Source = compressedBitmapImage,
                    Width = compressedBitmapImage.PixelWidth,
                    Height = compressedBitmapImage.PixelHeight
                };

                var paragraph = new Paragraph();
                paragraph.Inlines.Add(inlineUIContainer);
                _richTextBox.Document.Blocks.Add(paragraph);
                _richTextBox.Focus();
            }
        }

        public ICommand SelectColorCommand { get; private set; }
        private void ExecuteSelectColor(object parameter)
        {
            if (parameter is Brush brush)
            {
                IsColorChecked = false;
                FontColor = brush;
                _richTextBox.Selection.ApplyPropertyValue(TextElement.ForegroundProperty, FontColor);
                _richTextBox.Focus();
            }
        }

        public ICommand SelectCellCommand { get; private set; }
        private void ExecuteSelectCell(object parameter)
        {
            if (parameter is GridButton button)
            {
                IsGridChecked = false;

                Table table = new Table();

                for (int col = 0; col < button.Column; col++)
                {
                    table.Columns.Add(new TableColumn());
                }

                TableRowGroup rowGroup = new TableRowGroup();

                for (int row = 0; row < button.Row; row++)
                {
                    TableRow dataRow = new TableRow();

                    for (int col = 0; col < button.Column; col++)
                    {
                        dataRow.Cells.Add(new TableCell(new Paragraph()));
                    }

                    rowGroup.Rows.Add(dataRow);
                }

                table.RowGroups.Add(rowGroup);
                table.CellSpacing = 1;
                table.BorderBrush = Brushes.DarkGray;
                table.BorderThickness = new Thickness(0.5);

                foreach (TableRow row in table.RowGroups[0].Rows)
                {
                    foreach (TableCell cell in row.Cells)
                    {
                        cell.BorderBrush = Brushes.Black;
                        cell.BorderThickness = new Thickness(1);
                    }
                }

                _richTextBox.Document.Blocks.Add(table);
                _richTextBox.Focus();
            }
        }

        public ICommand PressTabCommand { get; private set; }
        private void ExecutePressTab(object parameter)
        {
            _richTextBox.CaretPosition.InsertTextInRun("\t");
        }
        #endregion
    }
}
