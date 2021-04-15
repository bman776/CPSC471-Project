using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLibrary.Models
{
    class SleepLog_db
    {

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public SleepLog_db()
        {
        }

        /// <summary>
        /// Fields constructor.
        /// </summary>
        public SleepLog_db(int id, DateTime date, TimeSpan time, TimeSpan sleepDuration)
        {
            Id = id;
            Date = date;
            Time = time;
            SleepDuration = sleepDuration;

        }

        #endregion

        #region Properties

        public int Id { get; set; }

        public DateTime Date { get; set; }

        public TimeSpan Time { get; set; }

        public TimeSpan SleepDuration { get; set; }

        #endregion
    }
}
