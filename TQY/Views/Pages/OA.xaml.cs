using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows; // 引用 Windows 以使用 RoutedEventArgs
using System.Windows.Controls;
using HandyControl.Controls;
using TQY.Helpers; // 引用 SessionHelper

namespace TQY.Views.Pages
{
    public partial class OA : HandyControl.Controls.Window, INotifyPropertyChanged
    {
        public class MenuItem
        {
            public string Name { get; set; } = string.Empty;
        }

        public List<MenuItem> DataList { get; set; }

        private object _currentView;
        public object CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        private MenuItem _selectedMenuItem;
        public MenuItem SelectedMenuItem
        {
            get => _selectedMenuItem;
            set
            {
                _selectedMenuItem = value;
                OnPropertyChanged();
                SwitchPage(value?.Name);
            }
        }

        public OA()
        {
            InitializeComponent();

            DataList = new List<MenuItem>
            {
                new MenuItem { Name = "项目总览" },
                new MenuItem { Name = "工程概况" },
                new MenuItem { Name = "工程文件" },
                new MenuItem { Name = "工程资料" },
                new MenuItem { Name = "工程影像" },
                new MenuItem { Name = "晴雨表" }
            };

            DataContext = this;
            CurrentView = new ProjectOverview();
        }

        // ★★★ 新增：退出登录事件 ★★★
        private void OnLogoutClick(object sender, RoutedEventArgs e)
        {
            // 1. 询问用户是否确认退出 (可选)
            // if (HandyControl.Controls.MessageBox.Show("确定要退出登录吗？", "提示", MessageBoxButton.YesNo, MessageBoxImage.Question) != MessageBoxResult.Yes) return;

            // 2. 清除本地登录凭证
            SessionHelper.Clear();

            // 3. 打开登录窗口
            var loginWindow = new LoginWindow();
            loginWindow.Show();

            // 4. 关闭当前 OA 窗口
            this.Close();
        }

        private void SwitchPage(string name)
        {
            if (string.IsNullOrEmpty(name)) return;

            switch (name)
            {
                case "项目总览":
                    CurrentView = new ProjectOverview();
                    break;
                case "工程概况":
                    CurrentView = CreatePlaceholder("工程概况页面 - 开发中");
                    break;
                case "工程文件":
                    CurrentView = CreatePlaceholder("工程文件管理模块");
                    break;
                case "工程资料":
                    CurrentView = CreatePlaceholder("工程资料归档模块");
                    break;
                case "工程影像":
                    CurrentView = CreatePlaceholder("施工现场影像记录");
                    break;
                case "晴雨表":
                    CurrentView = CreatePlaceholder("施工天气晴雨表");
                    break;
                default:
                    CurrentView = CreatePlaceholder("未知模块");
                    break;
            }
        }

        private object CreatePlaceholder(string text)
        {
            return new Border
            {
                Background = System.Windows.Media.Brushes.White,
                CornerRadius = new System.Windows.CornerRadius(10),
                Padding = new System.Windows.Thickness(30),
                Child = new TextBlock
                {
                    Text = text,
                    FontSize = 24,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Foreground = System.Windows.Media.Brushes.Gray
                }
            };
        }
        private void OnUserInfoClick(object sender, RoutedEventArgs e)
        {
            // 1. 取消左侧菜单的选中状态
            SelectedMenuItem = null;

            // 2. 切换右侧内容
            CurrentView = new UserInfoPage();
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}