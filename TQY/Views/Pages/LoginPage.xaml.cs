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
        //跳转到忘记密码页面
        private void OnForgotPassword(object sender, RoutedEventArgs e)
        {
            this.NavigationService!.Navigate(new ForgotPwdPage());
        }
        //跳转到注册页面
        private void OnRegister(object sender, RoutedEventArgs e)
        {
            this.NavigationService!.Navigate(new RegisterPage());
        }
    }
}
