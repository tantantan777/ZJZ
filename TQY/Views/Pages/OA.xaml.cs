using System.Collections.Generic;
using System.ComponentModel; // 必须引用
using System.Runtime.CompilerServices; // 必须引用
using System.Windows.Controls;
using HandyControl.Controls;

namespace TQY.Views.Pages
{
    public partial class OA : HandyControl.Controls.Window, INotifyPropertyChanged
    {
        public class MenuItem
        {
            public string Name { get; set; } = string.Empty;
        }

        public List<MenuItem> DataList { get; set; }

        // ★ 核心1：当前显示的页面内容
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

        // ★ 核心2：当前选中的菜单项
        private MenuItem _selectedMenuItem;
        public MenuItem SelectedMenuItem
        {
            get => _selectedMenuItem;
            set
            {
                _selectedMenuItem = value;
                OnPropertyChanged();
                // 当菜单选中项改变时，切换页面
                SwitchPage(value?.Name);
            }
        }

        public OA()
        {
            InitializeComponent();

            // 1. 更新菜单数据
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

            // 2. 默认显示“项目总览”
            CurrentView = new ProjectOverview();
        }

        // ★ 核心3：页面切换工厂逻辑
        private void SwitchPage(string name)
        {
            if (string.IsNullOrEmpty(name)) return;

            switch (name)
            {
                case "项目总览":
                    CurrentView = new ProjectOverview();
                    break;
                case "工程概况":
                    // CurrentView = new ProjectProfilePage(); // 以后创建了再打开注释
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

        // 临时占位符方法
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
                    HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                    VerticalAlignment = System.Windows.VerticalAlignment.Center,
                    Foreground = System.Windows.Media.Brushes.Gray
                }
            };
        }

        // 实现 INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}