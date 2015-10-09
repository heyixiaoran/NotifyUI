using System.Windows.Controls;
using MahApps.Metro.Controls;
using NotifyUI.Pages;

namespace NotifyUI
{
    /// <summary>
    /// PreferenceView.xaml 的交互逻辑
    /// </summary>
    public partial class PreferenceView : MetroWindow
    {
        private PageForScreenShot _scrrenShot;
        private PageForConnection _connection;
        private PageForPrivacy _privacy;

        public PreferenceView()
        {
            InitializeComponent();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedIndex = NAVlist.SelectedIndex;
            frame = frame ?? new Frame();

            switch (selectedIndex)
            {
                case 0:
                    if (_scrrenShot == null)
                    {
                        _scrrenShot = new PageForScreenShot();
                    }

                    frame.Navigate(_scrrenShot);
                    break;
                case 1:
                    if (_connection == null)
                    {
                        _connection = new PageForConnection();
                    }

                    frame.Navigate(_connection);
                    break;
                case 2:
                    if (_privacy == null)
                    {
                        _privacy = new PageForPrivacy();
                    }

                    frame.Navigate(_privacy);
                    break;
            }
        }
    }
}
