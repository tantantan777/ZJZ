using System.Windows;
using System.Windows.Controls;
using TQY.Views.Pages; // ← 按你的实际命名空间调整

namespace TQY.Views.Pages
{
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void OnForgotPassword(object sender, RoutedEventArgs e)
        {
            this.NavigationService!.Navigate(new ForgotPwdPage());
        }

        private void OnRegister(object sender, RoutedEventArgs e)
        {
            this.NavigationService!.Navigate(new RegisterPage());
        }
    }
}
