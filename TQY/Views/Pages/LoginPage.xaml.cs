using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using TQY.Services;
using TQY.ViewModels;

namespace TQY.Views.Pages
{
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();

            // 1. 读取配置
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            IConfiguration config = builder.Build();

            // 2. 创建服务
            var emailService = new EmailService(config);
            var dbService = new DatabaseService();

            // 3. 注入 ViewModel
            var viewModel = new LoginPageViewModel(emailService, dbService);

            // 4. 处理跳转 (比如登录成功后去 OA 首页)
            viewModel.NavigateToMainPageAction = () =>
            {
                // 这里假设你项目里有个 OA 页面
                this.NavigationService?.Navigate(new OA());
            };

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
    }
}