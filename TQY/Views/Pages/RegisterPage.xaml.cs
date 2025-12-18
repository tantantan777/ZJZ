using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TQY.Views.Pages
{
    /// <summary>
    /// RegisterPage.xaml 的交互逻辑
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }
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
        private void OpenUrl(string url)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }

        private void OnLogin(object sender, RoutedEventArgs e)
        {
            this.NavigationService!.Navigate(new LoginPage());
        }
    }
}
