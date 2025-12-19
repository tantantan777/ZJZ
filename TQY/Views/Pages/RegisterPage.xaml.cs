using HandyControl.Controls;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using TQY.ViewModels;



namespace TQY.Views.Pages
{
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
            DataContext = new RegisterViewModel();
        }

        //打开服务条款
        private void OnServicePolicy(object sender, RoutedEventArgs e)
        {
            var path = System.IO.Path.Combine(
                        AppDomain.CurrentDomain.BaseDirectory,
                        "Assets",
                        "Policies",
                        "service.html"
                    );
            OpenUrl(path);
        }
        //打开隐私政策
        private void OnPrivacyPolicy(object sender, RoutedEventArgs e)
        {
            var path = System.IO.Path.Combine(
                        AppDomain.CurrentDomain.BaseDirectory,
                        "Assets",
                        "Policies",
                        "privacy.html"
                    );
            OpenUrl(path);
        }
        //使用默认浏览器打开指定链接
        private void OpenUrl(string url)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }
        //返回登录页面
        private void OnLogin(object sender, RoutedEventArgs e)
        {
            this.NavigationService!.Navigate(new LoginPage());
        }

    }
}
