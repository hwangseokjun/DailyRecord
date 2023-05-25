using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DailyRecord.UserControls
{
    /// <summary>
    /// TextEditor.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TextEditor : UserControl
    {
        public TextEditor()
        {
            InitializeComponent();
        }

        private void BoldButton_Click(object sender, RoutedEventArgs e)
        {
            richTextBox?.Focus();

            TextSelection selection = richTextBox.Selection;

            if (selection.IsEmpty)
            {
                return;
            }

            if (boldToggleButton.IsChecked == true)
            {
                selection.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);
            }
            else 
            {
                selection.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Normal);
            }
        }

        private void ItalicButton_Click(object sender, RoutedEventArgs e)
        {
            richTextBox?.Focus();

            TextSelection selection = richTextBox.Selection;

            if (selection.IsEmpty)
            {
                return;
            }

            if (italicToggleButton.IsChecked == true)
            {
                selection.ApplyPropertyValue(TextElement.FontStyleProperty, FontStyles.Italic);
            }
            else
            {
                selection.ApplyPropertyValue(TextElement.FontStyleProperty, FontStyles.Normal);
            }
        }

        private void UnderlineButton_Click(object sender, RoutedEventArgs e)
        {
            richTextBox?.Focus();

            TextSelection selection = richTextBox.Selection;

            if (selection.IsEmpty)
            {
                return;
            }

            if (underlineToggleButton.IsChecked == true)
            {
                selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
            }
            else
            {
                selection.ApplyPropertyValue(Inline.TextDecorationsProperty, null);
            }
        }

        private void DecreaseButton_Click(object sender, RoutedEventArgs e)
        {
            richTextBox?.Focus();

            if (fontSizeComboBox.SelectedIndex <= 0)
            {
                return;
            }

            TextSelection selection = richTextBox.Selection;
            fontSizeComboBox.SelectedIndex -= 1;

            if (selection.IsEmpty)
            {
                return;
            }

            selection.ApplyPropertyValue(TextElement.FontSizeProperty, (double)fontSizeComboBox.SelectedItem);
        }

        private void IncreaseButton_Click(object sender, RoutedEventArgs e)
        {
            richTextBox?.Focus();

            if (fontSizeComboBox.Items.Count <= fontSizeComboBox.SelectedIndex + 1)
            {
                return;
            }

            TextSelection selection = richTextBox.Selection;
            fontSizeComboBox.SelectedIndex += 1;

            if (selection.IsEmpty)
            {
                return;
            }

            selection.ApplyPropertyValue(TextElement.FontSizeProperty, (double)fontSizeComboBox.SelectedItem);
        }

        private void FontColorButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void HighlightTextButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AlignStretchButton_Click(object sender, RoutedEventArgs e)
        {
            richTextBox?.Focus();

            richTextBox.Selection.ApplyPropertyValue(Block.TextAlignmentProperty, TextAlignment.Justify);
        }

        private void AlignLeftButton_Click(object sender, RoutedEventArgs e)
        {
            richTextBox?.Focus();

            richTextBox.Selection.ApplyPropertyValue(Block.TextAlignmentProperty, TextAlignment.Left);
        }

        private void AlignCenterButton_Click(object sender, RoutedEventArgs e)
        {
            richTextBox?.Focus();

            richTextBox.Selection.ApplyPropertyValue(Block.TextAlignmentProperty, TextAlignment.Center);
        }

        private void AlignRightButton_Click(object sender, RoutedEventArgs e)
        {
            richTextBox?.Focus();

            richTextBox.Selection.ApplyPropertyValue(Block.TextAlignmentProperty, TextAlignment.Right);
        }

        private void UploadImageButton_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "이미지 파일(*.jpg, *.png, *.gif)|*.jpg;*.jpeg;*.png;*.gif";

            if (openFileDialog.ShowDialog() == true)
            {
                Console.WriteLine(openFileDialog.FileName);
            }
        }

        private void FontFamilyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            richTextBox?.Focus();
        }

        private void FontSizeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            richTextBox?.Focus();
        }

        private void RichTextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
