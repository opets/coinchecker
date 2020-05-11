using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Base.Common
{
    public static class JavaScriptDateConverter
    {
        // 
        private static DateTime _jan1St1970 = new DateTime(1970, 1, 1);

        /// <summary>
        /// Converts a DateTime into a (JavaScript parsable) Int64.
        /// </summary>
        /// <param name="from">The DateTime to convert from</param>
        /// <returns>An integer value representing the number of milliseconds since 1 January 1970 00:00:00 UTC.</returns>
        public static long ToJsDateTime(DateTime from)
        {
            return System.Convert.ToInt64((from - _jan1St1970).TotalMilliseconds);
        }

        /// <summary>
        /// Converts a (JavaScript parsable) Int64 into a DateTime.
        /// </summary>
        /// <param name="from">An integer value representing the number of milliseconds since 1 January 1970 00:00:00 UTC.</param>
        /// <returns>The date as a DateTime</returns>
        public static DateTime FromJsDateTime(long from)
        {
            return _jan1St1970.AddMilliseconds(from);
        }
    }
}
