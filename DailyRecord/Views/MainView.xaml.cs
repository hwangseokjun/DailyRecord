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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DailyRecord.Views
{
    /// <summary>
    /// MainView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            Panel.SetZIndex(slidePanel, int.MaxValue);
            Storyboard storyboard = Resources["OpenStoryboard"] as Storyboard;
            storyboard.Begin();
        }

        private void OpacityGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Storyboard storyboard = Resources["CloseStoryboard"] as Storyboard;
            storyboard.Completed += Storyboard_Completed;
            storyboard.Begin();
        }

        private void Storyboard_Completed(object sender, EventArgs e)
        {
            Panel.SetZIndex(slidePanel, int.MinValue);
        }
    }
}
