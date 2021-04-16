using BusinessLibrary.Models;
using DatabaseLibrary.Core;
using DatabaseLibrary.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Webservice.ControllerHelpers
{
    public class CardioLogHelper
    {
        #region Converters

        /// <summary>
        /// Converts database models to a business logic object.
        /// </summary>
        public static BusinessLibrary.Models.CardioLog Convert(CardioLog_db instance)
        {
            if (instance == null)
                return null;
            return new BusinessLibrary.Models.CardioLog(instance.Id, instance.LogDate, instance.Time, instance.CaloriesBurned, instance.CardioType);
        }

        #endregion

        /// <summary>
        /// Signs up a student.
        /// </summary>
        /// <param name="includeDetailedErrors">States whether the internal server error message should be detailed or not.</param>
        public static ResponseMessage Add(JObject data,
            DbContext context, out HttpStatusCode statusCode, bool includeDetailedErrors = false)
        {
            // Extract paramters
            int id = (data.ContainsKey("id")) ? data.GetValue("id").Value<int>() : 0.0;
            DateTime logDate = (data.ContainsKey("logDate")) ? data.GetValue("logDate").Value<DateTime>() : DateTime.MinValue;
            TimeSpan time = (data.ContainsKey("time")) ? data.GetValue("time").Value<TimeSpan>() : null;
            int caloriesBurned = (data.ContainsKey("caloriesBurned")) ? data.GetValue("caloriesBurned").Value<int>() : 0.0;
            string cardioType = (data.ContainsKey("cardioType")) ? data.GetValue("cardioType").Value<string>() : null;

            // Add instance to database
            var dbInstance = DatabaseLibrary.Helpers.CardioLogHelper_db.Add(id, logDate, time, caloriesBurned, cardioType,
                context, out StatusResponse statusResponse);

            // Get rid of detailed internal server error message (when requested)
            if (statusResponse.StatusCode == HttpStatusCode.InternalServerError
                && !includeDetailedErrors)
                statusResponse.Message = "Something went wrong while adding a new cardio log.";

            // Return response
            var response = new ResponseMessage
                (
                    dbInstance != null,
                    statusResponse.Message,
                    Convert(dbInstance)
                );
            statusCode = statusResponse.StatusCode;
            return response;
        }

        /// <summary>
        /// Gets list of students.
        /// </summary>
        /// <param name="includeDetailedErrors">States whether the internal server error message should be detailed or not.</param>
        public static ResponseMessage GetCollection(
            DbContext context, out HttpStatusCode statusCode, bool includeDetailedErrors = false)
        {
            // Get instances from database
            var dbInstances = DatabaseLibrary.Helpers.CardioLog_db.GetCollection(
                context, out StatusResponse statusResponse);

            // Convert to business logic objects
            var instances = dbInstances?.Select(x => Convert(x)).ToList();

            // Get rid of detailed error message (when requested)
            if (statusResponse.StatusCode == HttpStatusCode.InternalServerError
                && !includeDetailedErrors)
                statusResponse.Message = "Something went wrong while retrieving the cardio log";

            // Return response
            var response = new ResponseMessage
                (
                    instances != null,
                    statusResponse.Message,
                    instances
                );
            statusCode = statusResponse.StatusCode;
            return response;
        }

        public static ResponseMessage GetCardioLog(JObject data,
            DbContext context, out HttpStatusCode statusCode, bool includeDetailedErrors = false)
        {

            int id = (data.ContainsKey("id")) ? data.GetValue("id").Value<int>() : 0;
            DateTime date = (data.ContainsKey("date")) ? data.GetValue("date").Value<DateTime>() : DateTime.MinValue;
            TimeSpan time = (data.ContainsKey("time")) ? data.GetValue("time").Value<TimeSpan>() : 0;
            var dbInstance = DatabaseLibrary.Helpers.CardioLogHelper_db.GetCardioLog(id, date, time,
                context, out StatusResponse statusResponse);

            var instances = dbInstances?.Select(x => Convert(x)).ToList();

            if (statusResponse.StatusCode == HttpStatusCode.InternalServerError
                && !includeDetailedErrors)
                statusResponse.Message = "Something went wrong while retrieving the cardio log";

            // Return response
            var response = new ResponseMessage
                (
                    instances != null,
                    statusResponse.Message,
                    instances
                );
            statusCode = statusResponse.StatusCode;
            return response;
        }

        public static ResponseMessage RemoveCardioLog(JObject data,
            DbContext context, out HttpStatusCode statusCode, bool includeDetailedErrors = false)
        {
            int id = (data.ContainsKey("id")) ? data.GetValue("id").Value<int>() : 0;
            DateTime date = (data.ContainsKey("date")) ? data.GetValue("date").Value<DateTime>() : DateTime.MinValue;
            TimeSpan time = (data.ContainsKey("time")) ? data.GetValue("time").Value<TimeSpan>() : 0;
            var dbInstance = DatabaseLibrary.Helpers.CardioLogHelper_db.DeleteCardioLog(id, date, time,
                context, out StatusResponse statusResponse);

            var instances = dbInstances?.Select(x => Convert(x)).ToList();

            if (statusResponse.StatusCode == HttpStatusCode.InternalServerError
                && !includeDetailedErrors)
                statusResponse.Message = "Something went wrong while removing the cardio log";

            var response = new ResponseMessage
                (
                    instances != null,
                    statusResponse.Message,
                    instances
                );
            statusCode = statusResponse.StatusCode;
            return response;
        }

        public static ResponseMessage EditCardioLog(JObject data,
            DbContext context, out HttpStatusCode statusCode, bool includeDetailedErrors = false)
        {
            int id = (data.ContainsKey("id")) ? data.GetValue("id").Value<int>() : 0.0;
            DateTime logDate = (data.ContainsKey("logDate")) ? data.GetValue("logDate").Value<DateTime>() : DateTime.MinValue;
            TimeSpan time = (data.ContainsKey("time")) ? data.GetValue("time").Value<TimeSpan>() : null;
            int caloriesBurned = (data.ContainsKey("caloriesBurned")) ? data.GetValue("caloriesBurned").Value<int>() : 0.0;
            string cardioType = (data.ContainsKey("cardioType")) ? data.GetValue("cardioType").Value<string>() : null;
            var dbInstance = DatabaseLibrary.Helpers.CardioLogHelper_db.EditCardioLog(id, name, date, startTime, endTime, caloriesBurned, exerciseType,
                context, out StatusResponse statusResponse);

            var instances = dbInstances?.Select(x => Convert(x)).ToList();

            if (statusResponse.StatusCode == HttpStatusCode.InternalServerError
                && !includeDetailedErrors)
                statusResponse.Message = "Something went wrong while editting the cardio log";

            var response = new ResponseMessage
                (
                    instances != null,
                    statusResponse.Message,
                    instances
                );
            statusCode = statusResponse.StatusCode;
            return response;
        }
    }
}