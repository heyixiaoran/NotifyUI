using System.Windows;

namespace NotifyUI
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            LoginView window = new LoginView();
            bool? dialogResult = window.ShowDialog();
            if (dialogResult.HasValue && dialogResult.Value)
            {
                base.OnStartup(e);
                Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
            }
            else
            {
                this.Shutdown();
            }
        }
    }
}
