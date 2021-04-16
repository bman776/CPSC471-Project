using Nest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLibrary.Models
{
	public class CardioLog
    {
		#region Constructors

		public CardioLog()
        {

        }

		public CardioLog(int id, string logName, DateTime logDate, TimeSpan startTime, TimeSpan endTime, int caloriesBurned, string cardioType)
        {
			Id = id;
			LogName = logName;
			LogDate = logDate;
			StartTime = startTime;
			EndTime = endTime;
			CaloriesBurned = caloriesBurned;
			CardioType = cardioType;
        }

        public CardioLog(CardioLog instance)
            : this(instance.Id, instance.LogName, instance.LogDate, instance.StartTime, instance.EndTime, instance.CaloriesBurned, instance.CardioType)
        {
        }

		#endregion

		#region Properties

		[JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[JsonProperty(PropertyName = "logName")]
		public string LogName;

		[JsonProperty(PropertyName = "logDate")]
		public DateTime LogDate { get; set; }

		[JsonProperty(PropertyName = "startTime")]
		public TimeSpan StartTime { get; set; }

		[JsonProperty(PropertyName = "endTime")]
		public TimeSpan EndTime { get; set; }

		[JsonProperty(PropertyName = "caloriesBurned")]
		public int CaloriesBurned { get; set; }

		[JsonProperty(PropertyName = "cardioType")]
		public string CardioType { get; set; }

		#endregion

		#region Methods

		#endregion
	}
}