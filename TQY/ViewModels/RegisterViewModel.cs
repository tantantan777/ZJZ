using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TQY.ViewModels
{
    public partial class RegisterViewModel : ObservableObject
    {
        // 使用 ObservableProperty 自动生成属性和通知
        [ObservableProperty]
        private string email1;

        // 获取验证码命令
        public RelayCommand GetCodeCommand { get; }

        public RegisterViewModel()
        {
            GetCodeCommand = new RelayCommand(() =>
            {
                // TODO: 获取验证码逻辑
            });
        }
    }
}
