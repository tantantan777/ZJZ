using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TQY.ViewModels
{
    public partial class LoginPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string email1;

        public RelayCommand GetCodeCommand { get; }

        public LoginPageViewModel()
        {
            GetCodeCommand = new RelayCommand(() =>
            {
                // TODO: 获取验证码逻辑
            });
        }
    }
}
