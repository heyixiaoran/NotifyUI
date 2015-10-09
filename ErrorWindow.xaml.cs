using System.Windows;
using MahApps.Metro.Controls;

namespace NotifyUI
{
    /// <summary>
    /// Interaction logic for ErrorWindow.xaml
    /// </summary>
    public partial class ErrorWindow : MetroWindow
    {
        public ErrorWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
