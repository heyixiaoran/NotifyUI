using System;
using System.Collections.Generic;
using System.Management;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using MahApps.Metro.Controls;

namespace NotifyUI
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow
    {

        private bool _isOpen = false;

        private IList<string> Sources { get; set; }

        bool _isFirstRun = true;

        public MainWindow()
        {
            InitializeComponent();

            this.Left = SystemParameters.WorkArea.Width - this.Width;
            this.Top = SystemParameters.WorkArea.Height - this.Height;

            GetSources();
        }

        private void GetSources()
        {
            Sources = new List<string>();
            Sources.Add("1");
            Sources.Add("2");
            Sources.Add("3");
            Sources.Add("4");

            cbForProject.ItemsSource = Sources;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Up();
        }

        public void OnCancelClick(object sender, RoutedEventArgs e)
        {
            Down();
        }

        public void OnSubmitClick(object sender, RoutedEventArgs e)
        {
            Down();
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //  显示图片
            MainGrid.IsEnabled = false;
            LoaderImage.Visibility = Visibility.Visible;

            //  模拟计算任务
            Thread t = new Thread(() =>
            {
                //  线程休眠3秒
                Thread.Sleep(3000);

                Dispatcher.Invoke(new Action(() =>
                {
                    //  隐藏图片
                    MainGrid.IsEnabled = true;
                    LoaderImage.Visibility = Visibility.Hidden;
                }));

            });
            t.Start();
        }

        private void Up()
        {
            if(_isOpen) return;

            if (_isFirstRun)
            {
                this.Height = 146;
                _isFirstRun = false;
            }

            Storyboard sb1 = new Storyboard();

            if((SystemParameters.WorkArea.Height - Top - Height) <= 260)
            {
                DoubleAnimationUsingKeyFrames da1 = new DoubleAnimationUsingKeyFrames();
                var top = SystemParameters.WorkArea.Height - this.Height;
                da1.KeyFrames.Add(new LinearDoubleKeyFrame(top, TimeSpan.FromSeconds(0)));
                da1.KeyFrames.Add(new LinearDoubleKeyFrame(top - 260, TimeSpan.FromSeconds(1)));
                Storyboard.SetTarget(da1, metroWindow);
                Storyboard.SetTargetProperty(da1, new PropertyPath("Top"));
                sb1.Children.Add(da1);
            }

            DoubleAnimationUsingKeyFrames da2 = new DoubleAnimationUsingKeyFrames();
            da2.KeyFrames.Add(new LinearDoubleKeyFrame(146, TimeSpan.FromSeconds(0)));
            da2.KeyFrames.Add(new LinearDoubleKeyFrame(406, TimeSpan.FromSeconds(1)));
            Storyboard.SetTarget(da2, metroWindow);
            Storyboard.SetTargetProperty(da2, new PropertyPath("Height"));
            sb1.Children.Add(da2);

            DoubleAnimationUsingKeyFrames da3 = new DoubleAnimationUsingKeyFrames();
            da3.KeyFrames.Add(new LinearDoubleKeyFrame(0, TimeSpan.FromSeconds(0)));
            da3.KeyFrames.Add(new LinearDoubleKeyFrame(260, TimeSpan.FromSeconds(1)));
            Storyboard.SetTarget(da3, grid);
            Storyboard.SetTargetProperty(da3, new PropertyPath("Height"));
            sb1.Children.Add(da3);

            sb1.Begin(this);

            _isOpen = true;
        }

        private void Down()
        {
            Storyboard sb2 = new Storyboard();

            if((SystemParameters.WorkArea.Height -Top - Height) <= 0)
            {
                DoubleAnimationUsingKeyFrames da1 = new DoubleAnimationUsingKeyFrames();
                var top = SystemParameters.WorkArea.Height - this.Height;
                da1.KeyFrames.Add(new LinearDoubleKeyFrame(top, TimeSpan.FromSeconds(0)));
                da1.KeyFrames.Add(new LinearDoubleKeyFrame(top + 260, TimeSpan.FromSeconds(1)));
                Storyboard.SetTarget(da1, metroWindow);
                Storyboard.SetTargetProperty(da1, new PropertyPath("Top"));
                sb2.Children.Add(da1);
            }

            DoubleAnimationUsingKeyFrames da2 = new DoubleAnimationUsingKeyFrames();
            da2.KeyFrames.Add(new LinearDoubleKeyFrame(406, TimeSpan.FromSeconds(0)));
            da2.KeyFrames.Add(new LinearDoubleKeyFrame(146, TimeSpan.FromSeconds(1)));
            Storyboard.SetTarget(da2, metroWindow);
            Storyboard.SetTargetProperty(da2, new PropertyPath("Height"));
            sb2.Children.Add(da2);

            DoubleAnimationUsingKeyFrames da3 = new DoubleAnimationUsingKeyFrames();
            da3.KeyFrames.Add(new LinearDoubleKeyFrame(260, TimeSpan.FromSeconds(0)));
            da3.KeyFrames.Add(new LinearDoubleKeyFrame(0, TimeSpan.FromSeconds(1)));
            Storyboard.SetTarget(da3, grid);
            Storyboard.SetTargetProperty(da3, new PropertyPath("Height"));
            sb2.Children.Add(da3);

            sb2.Begin(this);

            _isOpen = false;

        }

        private void ButtonBaseOnClick(object sender, RoutedEventArgs e)
        {
            if((bool)ToggleButton.IsChecked)
            {
                Image.Source = new BitmapImage(new Uri(@"Image\pause.ico", UriKind.Relative));
            }
            else
            {
                Image.Source = new BitmapImage(new Uri(@"Image\play.ico", UriKind.Relative));
            }
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            var preference = new PreferenceView();
            preference.ShowDialog();

        }
    }
}
