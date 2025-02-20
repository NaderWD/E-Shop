using System.Globalization;

namespace E_Shop.Application.Tools
{


    public static class DateTimeExtensions
    {
        public static string ToShamsi(this DateTime date)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(date) + "/" +
                pc.GetMonth(date).ToString("00") + "/" +
                pc.GetDayOfMonth(date).ToString("00");
        }
    }
}
