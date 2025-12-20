using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HandyControl.Controls; // 引用 HandyControl 的控件
using TQY.Services;
using System.Windows;
using MessageBox = HandyControl.Controls.MessageBox; // 指定使用 HandyControl 的弹窗

namespace TQY.ViewModels
{
    public partial class RegisterViewModel : ObservableObject
    {
        private readonly EmailService _emailService;
        private readonly IDatabaseService _dbService;

        public Action? NavigateToLoginAction { get; set; }


        [ObservableProperty]
        private string _email1 = string.Empty;
        

        [ObservableProperty]
        private string _code = string.Empty;

        [ObservableProperty]
        private bool _isAgreed; // 是否同意协议

        // 构造函数：注入服务
        public RegisterViewModel(EmailService emailService, IDatabaseService dbService)
        {
            _emailService = emailService;
            _dbService = dbService;
        }

        // 1. 获取验证码命令
        [RelayCommand]
        private async Task GetCode()
        {
            if (string.IsNullOrEmpty(Email1))
            {
                MessageBox.Warning("请输入电子邮箱！");
                return;
            }

            // 发送验证码
            bool isSent = await _emailService.SendCodeAsync(Email1);
            if (isSent)
            {
                MessageBox.Success($"验证码已发送至 {Email1}");
            }
            else
            {
                MessageBox.Error("验证码发送失败，请检查网络或邮箱配置。");
            }
        }

        // 2. 注册命令
        // 注意：密码框为了安全，不能直接绑定，必须通过 CommandParameter 传进来
        [RelayCommand]
        private async Task Register(object parameter)
        {
            // (1) 基础校验
            if (!IsAgreed)
            {
                MessageBox.Warning("请先阅读并同意服务条款！");
                return;
            }

            if (parameter is not HandyControl.Controls.PasswordBox pwdBox) return;
            string password = pwdBox.Password;

            if (string.IsNullOrEmpty(Email1) || string.IsNullOrEmpty(Code) || string.IsNullOrEmpty(password))
            {
                MessageBox.Warning("请填写完整信息（邮箱、验证码、密码）");
                return;
            }

            // (2) 校验验证码
            if (!_emailService.VerifyCode(Email1, Code))
            {
                MessageBox.Error("验证码错误或已过期！");
                return;
            }

            // (3) 调用数据库注册
            var result = await _dbService.RegisterAsync(Email1, password);
            if (result.IsSuccess)
            {
                MessageBox.Success("注册成功！即将返回登录页...");
                // 注册成功后，可以在这里写跳转逻辑，或者通过事件通知 View 关闭
                pwdBox.Password = ""; // 清空密码

                await Task.Delay(1500);

                NavigateToLoginAction?.Invoke();
            }
            else
            {
                MessageBox.Error(result.Message); // 显示如“邮箱已存在”等错误
            }
        }
    }
}