using System;
using System.Globalization;
using System.Windows.Data;

namespace TQY.Converters
{
    public class EmailValidMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 2) return false;

            string text = values[0] as string;
            bool hasError = values[1] is bool b && b;

            // Text为空 或 有错误 → 按钮禁用
            return !string.IsNullOrWhiteSpace(text) && !hasError;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
