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

        public CardioLog_db(int id, DateTime logDate, TimeSpan time, int caloriesBurned, string cardioType)
        {
            Id = id;
            LogDate = logDate;
            Time = time;
            CaloriesBurned = caloriesBurned;
            CardioType = cardioType;
        }

        #endregion

        #region Properties

        public int Id { get; set; }

        public DateTime LogDate { get; set; }

        public TimeSpan Time { get; set; }

        public int CaloriesBurned { get; set; }
        public string CardioType { get; set; }

        #endregion
    }
}