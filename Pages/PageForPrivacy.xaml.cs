using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace NotifyUI.Pages
{
    /// <summary>
    /// PageForPrivacy.xaml 的交互逻辑
    /// </summary>
    public partial class PageForPrivacy : Page
    {
        public PageForPrivacy()
        {
            InitializeComponent();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
