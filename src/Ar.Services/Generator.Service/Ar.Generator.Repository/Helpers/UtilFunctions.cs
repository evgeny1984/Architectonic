using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Ar.Generator.Repository.Helpers
{
    public static class UtilFunctions
    {
        private static readonly Regex DataUriPattern = new Regex(@"^data\:(?<type>image\/(png|tiff|jpg|jpeg|gif));base64,(?<data>[A-Z0-9\+\/\=]+)$", RegexOptions.Compiled | RegexOptions.ExplicitCapture | RegexOptions.IgnoreCase);

        /// <summary>
        /// Get the calendar week number by date
        /// </summary>
        /// <param name="date">The date</param>
        /// <returns>The number of the week</returns>
        public static int CalendarWeek(this DateTime date)
        {
            CultureInfo currentCulture = CultureInfo.CurrentCulture;

            // Get current calendar
            Calendar calendar = currentCulture.Calendar;

            // Get calendar week from the Calendar-Object 
            int calendarWeek = calendar.GetWeekOfYear(date,
               currentCulture.DateTimeFormat.CalendarWeekRule,
               currentCulture.DateTimeFormat.FirstDayOfWeek);

            // Check if calendar week > 52 then calculate the correct value
            if (calendarWeek > 52)
            {
                date = date.AddDays(7);
                int testCalendarWeek = calendar.GetWeekOfYear(date,
                   currentCulture.DateTimeFormat.CalendarWeekRule,
                   currentCulture.DateTimeFormat.FirstDayOfWeek);
                if (testCalendarWeek == 2)
                    calendarWeek = 1;
            }

            return calendarWeek;
        }

        public static string GetHashBase64(string aInput)
        {
            using (SHA1Managed hash = new SHA1Managed())
            {
                return Convert.ToBase64String(hash.ComputeHash(Encoding.UTF8.GetBytes(aInput)));
            }
        }

        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

    }
}
