using System;
using System.Globalization;
using System.Windows.Data;

namespace Agenda.Converters
{
    public abstract class GenericConverter<From, To> : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var from = (From) value;
            return DoConvert(from);
        }

        protected abstract To DoConvert(From from);

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var to = (To) value;
            return DoConvertBack(to);
        }

        protected abstract From DoConvertBack(To value);
    }

    [ValueConversion(typeof(DateTime), typeof(string))]
    public class DateToStringConverter : GenericConverter<DateTime, string>
    {
        public DateToStringConverter()
        {
        }

        protected override string DoConvert(DateTime from)
        {
            return from.ToLongDateString();
        }

        protected override DateTime DoConvertBack(string value)
        {
            return DateTime.Parse(value);
        }
    }
}