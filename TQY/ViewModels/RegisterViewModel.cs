using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace TQY.ViewModels
{
    // 注册界面的业务逻辑类
    public class RegisterViewModel : ViewModelBase
    {
        private string _email1;

        public string Email1
        {
            get => _email1;
            set => Set(ref _email1, value);
        }

        // 获取验证码命令
        public RelayCommand GetCodeCommand { get; }

        public RegisterViewModel()
        {
            // 按钮点击逻辑
            GetCodeCommand = new RelayCommand(() =>
            {
                // TODO: 获取验证码逻辑
            });
        }
    }
}
