using System.Globalization;

namespace E_Shop.Application.Tools
{
    public static class DateTimeExtensions
    {
        public static string ToShamsi(this DateTime date)        
        {
            var persianCalendar = new PersianCalendar();
            return $"{persianCalendar.GetYear(date)}/{persianCalendar.GetMonth(date)}/{persianCalendar.GetDayOfMonth(date)}";
        }
    }
}
