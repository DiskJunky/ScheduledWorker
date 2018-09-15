namespace ScheduledWorker.Library.Core.Schedule
{
    using System;
    using System.Globalization;
    using System.Threading;
    using Contracts;
    using Contracts.Schedule;

    /// <summary>
    /// This schedule item describes the month, day and time that a task should kick off at.
    /// </summary>
    /// <seealso cref="ScheduledWorker.Library.Core.Schedule.DailyScheduleItem" />
    /// <seealso cref="ScheduledWorker.Library.Contracts.Schedule.IMonthlyScheduleItem" />
    public class MonthlyScheduleItem : DailyScheduleItem, IMonthlyScheduleItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MonthlyScheduleItem"/> class.
        /// </summary>
        /// <param name="time">The time of day that the task should kick off at.</param>
        /// <param name="month">The month that the task should kick off at.</param>
        /// <param name="day">The day that the task should kick off at.</param>
        /// <exception cref="FormatException"></exception>
        public MonthlyScheduleItem(DateTime time, Months month, int day)
            : base(time)
        {
            if (!IsValidDate(month, day))
            {
                throw new FormatException($"Unable to recognise a validate date from month [{month}] and day [{day}].");
            }

            Month = month;
            Day = day;
        }

        /// <summary>
        /// Gets the month the task is to be triggered at.
        /// </summary>
        public Months Month { get; }

        /// <summary>
        /// Gets the day of the month to be triggered at.
        /// </summary>
        public int Day { get; }

        /// <summary>
        /// Determines whether the date component comprise a valid date.
        /// </summary>
        /// <param name="month">The month to validate.</param>
        /// <param name="day">The day to validate.</param>
        /// <returns>
        ///   <c>true</c> if the date is valid otherwise, <c>false</c>.
        /// </returns>
        private bool IsValidDate(Months month, int day)
        {
            var test = $"2000-{(int)month}-{day.ToString("N2")}";  // NOTE: 2000=to allow for leap year values
            DateTime parsed;
            return DateTime.TryParseExact(test,
                                          "yyyy-MM-dd",
                                          Thread.CurrentThread.CurrentCulture,
                                          DateTimeStyles.NoCurrentDateDefault,
                                          out parsed);
        }
    }
}
