using System.Windows;
using System.Windows.Controls;

namespace TQY.Views.Pages
{
    /// <summary>
    /// ForgotPwdPage.xaml 的交互逻辑
    /// </summary>
    public partial class ForgotPwdPage : Page
    {
        public ForgotPwdPage()
        {
            InitializeComponent();
        }
        private void OnLogin(object sender, RoutedEventArgs e)
        {
            this.NavigationService!.Navigate(new LoginPage());
        }
    }
}
