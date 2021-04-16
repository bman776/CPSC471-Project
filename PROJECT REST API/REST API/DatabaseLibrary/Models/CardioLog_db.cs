using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLibrary.Models
{
    public class CardioLog_db
    {
        #region Constructors
        public CardioLog_db()
        {

        }

        public CardioLog_db(int id, string logName, DateTime logDate, TimeSpan startTime, TimeSpan endTime, int caloriesBurned, string cardioType)
        {
            Id = id;
            LogName = logName;
            LogDate = logDate;
            StartTime = startTime;
            EndTime = endTime;
            CaloriesBurned = caloriesBurned;
            CardioType = cardioType;
        }

        #endregion

        #region Properties

        public int Id { get; set; }

        public string LogName;

        public DateTime LogDate { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public int CaloriesBurned { get; set; }

        public string CardioType { get; set; }

        #endregion
    }
}