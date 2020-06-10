using System;

namespace PowerExtensions
{
    public static class DateTimeExtensions
    {
        public static DateTime ToDateTime(this string s, string format = "dd/MM/yyyy")
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Check if the target DateTime is in 2 threshold values
        /// </summary>
        /// <param name="target">The target date</param>
        /// <param name="left">The left threshold</param>
        /// <param name="right">The right threshold</param>
        /// <param name="mode">The compare mode</param>
        /// <returns>return true if the given value is in range, otherwise return false</returns>
        public static bool IsInRange(this DateTime target, DateTime left, DateTime right, DateTimeRangeMode mode = DateTimeRangeMode.Including)
        {
            if (target < left || target > right)
            {
                return false;
            }

            if (mode == DateTimeRangeMode.Including)
            {
                return left <= target || target <= right;
            }

            // non including
            return left < target && target < right;
        }

        /// <summary>
        /// Check if 2 parts is intersect with each other
        /// </summary>
        /// <param name="left2">The (left1, right1) part</param>
        /// <param name="right2">The (left2, right2) part</param>
        /// <returns>return true if 2 parts intersect</returns>
        public static bool IsIntersect((DateTime left1, DateTime right1) part1, (DateTime left2, DateTime right2) part2, DateTimeRangeMode mode = DateTimeRangeMode.Including)
        {
            var (left1, right1) = part1;
            var (left2, right2) = part2;

            if (mode == DateTimeRangeMode.Including)
            {
                return left2 <= right1 && left1 <= right2;
            }

            return left2 < right1 && right2 > left1;
        }

        /// <summary>
        /// Return the start of the month of the given date
        /// </summary>
        /// <param name="dateTime">The date</param>
        /// <param name="keepHour">Keep hour or not</param>
        /// <returns>The start of month</returns>
        public static DateTime ToStartOfMonth(this DateTime dateTime, bool keepHour = false)
        {
            if (keepHour)
            {
                return new DateTime(dateTime.Year, dateTime.Month, 1, dateTime.Hour, dateTime.Minute, dateTime.Second);
            }
            
            return new DateTime(dateTime.Year, dateTime.Month, 1);
        }

        /// <summary>
        /// Return the end of the month of the given date
        /// </summary>
        /// <param name="dateTime">The date</param>
        /// <param name="keepHour">Keep hour or not</param>
        /// <returns>The end of month</returns>
        public static DateTime ToEndOfMonth(this DateTime dateTime, bool keepHour = false)
        {
            return dateTime
                .AddMonths(1)
                .ToStartOfMonth(keepHour)
                .AddDays(-1);
        }
    }

    public enum DateTimeRangeMode
    {
        Including,
        NotIncluding
    }
}