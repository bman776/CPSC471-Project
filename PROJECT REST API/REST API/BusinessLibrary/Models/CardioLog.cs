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

		public CardioLog(int id, DateTime logDate, TimeSpan time, int caloriesBurned, string cardioType)
        {
			Id = id;
			LogDate = logDate;
			Time = time;
			CaloriesBurned = caloriesBurned;
			CardioType = cardioType;
        }

        public CardioLog(CardioLog instance)
            : this(instance.Id, instance.LogDate, instance.Time, instance.CaloriesBurned, instance.CardioType)
        {
        }

		#endregion

		#region Properties

		[JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[JsonProperty(PropertyName = "logDate")]
		public DateTime LogDate { get; set; }

		[JsonProperty(PropertyName = "time")]
		public TimeSpan Time { get; set; }

		[JsonProperty(PropertyName = "caloriesBurned")]
		public int CaloriesBurned { get; set; }

		[JsonProperty(PropertyName = "cardioType")]
		public string CardioType { get; set; }

		#endregion

		#region Methods

		#endregion
	}
}