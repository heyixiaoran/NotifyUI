using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using MahApps.Metro.Controls;

namespace NotifyUI
{
    /// <summary>
    /// LoginView.xaml 的交互逻辑
    /// </summary>
    public partial class LoginView : MetroWindow
    {
        private Storyboard _sb;

        public LoginView()
        {
            InitializeComponent();
            GetSouces();
        }

        private void GetSouces()
        {
            var list = new List<string>();
            list.Add("Available");
            list.Add("Unavailable");
            cbBoxForStatus.ItemsSource = list;
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //MainPanel.IsEnabled = false;

            _sb = new Storyboard();
            _sb.FillBehavior = FillBehavior.Stop;
            _sb.RepeatBehavior = RepeatBehavior.Forever;
            DoubleAnimationUsingKeyFrames da2 = new DoubleAnimationUsingKeyFrames();
            da2.KeyFrames.Add(new LinearDoubleKeyFrame(30, TimeSpan.FromSeconds(0.1)));
            da2.KeyFrames.Add(new LinearDoubleKeyFrame(60, TimeSpan.FromSeconds(0.2)));
            da2.KeyFrames.Add(new LinearDoubleKeyFrame(90, TimeSpan.FromSeconds(0.3)));
            da2.KeyFrames.Add(new LinearDoubleKeyFrame(120, TimeSpan.FromSeconds(0.4)));
            da2.KeyFrames.Add(new LinearDoubleKeyFrame(150, TimeSpan.FromSeconds(0.5)));
            da2.KeyFrames.Add(new LinearDoubleKeyFrame(180, TimeSpan.FromSeconds(0.6)));
            Storyboard.SetTarget(da2, Button);
            Storyboard.SetTargetProperty(da2, new PropertyPath("(UIElement.RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)"));
            _sb.Children.Add(da2);
            _sb.Begin();

            //  延时打开DockWindow
            Thread t = new Thread(() =>
            {
                Thread.Sleep(3000);
                Dispatcher.Invoke(new Action(() =>
                {

                    if (userName.Text == "1")
                    {
                        _sb.Stop();
                        Close();
                        var dockView = new MainWindow();
                        dockView.ShowDialog();
                    }
                    else
                    {
                        _sb.Stop();
                        var errorWindow = new ErrorWindow();
                        errorWindow.ShowDialog();
                    }
                }));
            });

            t.Start();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var preference = new PreferenceView();
            preference.ShowDialog();
        }
    }
}
