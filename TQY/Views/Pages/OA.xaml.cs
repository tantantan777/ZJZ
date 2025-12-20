using System.Collections.Generic;
using HandyControl.Controls; // ★ 引入 HandyControl 命名空间

namespace TQY.Views.Pages
{
    // ★ 关键修改：类必须继承自 HandyControl.Controls.Window，以匹配 XAML 中的 <hc:Window>
    public partial class OA : HandyControl.Controls.Window
    {
        // 简单的菜单模型
        public class MenuItem
        {
            public string Name { get; set; } = string.Empty;
        }

        // 前端 ListBox 绑定的数据源
        public List<MenuItem> DataList { get; set; }

        public OA()
        {
            InitializeComponent();

            // 初始化菜单数据
            DataList = new List<MenuItem>
            {
                new MenuItem { Name = "项目总览" },
                new MenuItem { Name = "工程概况" },
                new MenuItem { Name = "工程文件" },
                new MenuItem { Name = "工程资料" },
                new MenuItem { Name = "工程影像" },
                new MenuItem { Name = "晴雨表" }
            };

            // 设置数据上下文，让 XAML 能读取到 DataList
            DataContext = this;
        }
    }
}