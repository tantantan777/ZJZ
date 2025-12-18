using System.Windows;
using System.Windows.Controls;

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
