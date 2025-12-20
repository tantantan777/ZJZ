using System;
using System.Globalization;
using System.Windows.Data;

namespace TQY.Converters
{
    public class EmailValidMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            // 我们预期接收 3 个值：
            // [0]: 邮箱文本 (string)
            // [1]: 是否有验证错误 (bool)
            // [2]: 是否正在发送倒计时 (bool)

            if (values.Length < 3) return false;

            var text = values[0] as string;
            bool hasError = values[1] is bool b1 && b1;     // True 代表有红色错误
            bool isSending = values[2] is bool b2 && b2;    // True 代表正在倒计时

            // 只有当：有文本 & 没错误 & 没在倒计时，按钮才可用
            return !string.IsNullOrWhiteSpace(text) && !hasError && !isSending;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}