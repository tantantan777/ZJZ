using HandyControl.Controls;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using TQY.Services;
using TQY.ViewModels;



namespace TQY.Views.Pages
{
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
            // 1. 手动构建配置读取器 (为了读取 appsettings.json)
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            IConfiguration config = builder.Build();

            // 2. 实例化服务
            var emailService = new EmailService(config);
            var dbService = new DatabaseService();
            var viewModel = new RegisterViewModel(emailService, dbService);
            
            viewModel.NavigateToLoginAction = () =>
            {
                // 只有在 UI 线程才能操作界面跳转
                this.Dispatcher.Invoke(() =>
                {
                    this.NavigationService?.Navigate(new LoginPage());
                });
            };

            // 4. 最后赋值给 DataContext
            DataContext = viewModel;
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
