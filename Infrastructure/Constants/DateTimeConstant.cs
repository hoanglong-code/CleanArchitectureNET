using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Constants
{
    public class DateTimeConstant
    {
        public const string DefaultFormatDateTime = "yyyy-MM-dd hh:ss";

        public static string? CheckValidDateTime(DateTime? dateTime)
        {
            DateTime result;

            if (dateTime == null) return null;

            return DateTime.TryParseExact(dateTime.Value.ToString(), DefaultFormatDateTime, CultureInfo.InvariantCulture, DateTimeStyles.None, out result) ? dateTime.ToString() : null;
        }

        public static string GetCurrentYear() => (DateTime.Now.Year % 100).ToString();
    }
}
