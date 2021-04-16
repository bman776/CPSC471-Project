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
    public class ExerciseSetHelper
    {
        #region Converters

        public static BusinessLibrary.Models.ExerciseSet Convert(ExerciseSet_db instance)
        {
            if (instance == null)
                return null;
            return new BusinessLibrary.Models.ExerciseSet(instance.Id, instance.Date, instance.Time, instance.Weight, instance.Type, instance.Reps, instance.SetNumber);
        }

        #endregion

        public static ResponseMessage Add(JObject data,
            DbContext context, out HttpStatusCode statusCode, bool includeDetailedErrors = false)
        {
            // Extract paramters
            int id = (data.ContainsKey("id")) ? data.GetValue("id").Value<int>() : 0;
            DateTime date = (data.ContainsKey("date")) ? data.GetValue("date").Value<DateTime>() : DateTime.MinValue;
            TimeSpan time = (data.ContainsKey("time")) ? data.GetValue("time").Value<TimeSpan>() : null;
            int weight = (data.ContainsKey("weight")) ? data.GetValue("weight").Value<int>() : 0;
            string type = (data.ContainsKey("type")) ? data.GetValue("type").Value<string>() : null;
            int reps = (data.ContainsKey("reps")) ? data.GetValue("reps").Value<int>() : 0;
            int setNumber = (data.ContainsKey("setNumber")) ? data.GetValue("setNumber").Value<int>() : 0;
            

            // Add instance to database
            var dbInstance = DatabaseLibrary.Helpers.ExerciseSetHelper_db.Add(id, date, time, weight, type, reps, setNumber,
                context, out StatusResponse statusResponse);

            // Get rid of detailed internal server error message (when requested)
            if (statusResponse.StatusCode == HttpStatusCode.InternalServerError
                && !includeDetailedErrors)
                statusResponse.Message = "Something went wrong while adding a new Exercise Set.";

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
            var dbInstances = DatabaseLibrary.Helpers.ExerciseSetHelper_db.GetCollection(
                context, out StatusResponse statusResponse);

            // Convert to business logic objects
            var instances = dbInstances?.Select(x => Convert(x)).ToList();

            // Get rid of detailed error message (when requested)
            if (statusResponse.StatusCode == HttpStatusCode.InternalServerError
                && !includeDetailedErrors)
                statusResponse.Message = "Something went wrong while retrieving the Exercise Sets";

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

        public static ResponseMessage GetExerciseSet(JObject data,
            DbContext context, out HttpStatusCode statusCode, bool includeDetailedErrors = false)
        {
            int id = (data.ContainsKey("id")) ? data.GetValue("id").Value<int>() : 0;
            DateTime date = (data.ContainsKey("date")) ? data.GetValue("date").Value<DateTime>() : DateTime.MinValue;
            TimeSpan time = (data.ContainsKey("time")) ? data.GetValue("time").Value<TimeSpan>() : null;
            var dbInstance = DatabaseLibrary.Helpers.ExerciseSetHelper_db.GetExerciseSet(id, date, time,
                context, out StatusResponse statusResponse);

            var instances = dbInstances?.Select(x => Convert(x)).ToList();

            if (statusResponse.StatusCode == HttpStatusCode.InternalServerError
                && !includeDetailedErrors)
                statusResponse.Message = "Something went wrong while retrieving the ExerciseSet";

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

        public static ResponseMessage RemoveExerciseSet(JObject data,
            DbContext context, out HttpStatusCode statusCode, bool includeDetailedErrors = false)
        {

            int id = (data.ContainsKey("id")) ? data.GetValue("id").Value<int>() : 0;
            DateTime date = (data.ContainsKey("date")) ? data.GetValue("date").Value<DateTime>() : DateTime.MinValue;
            TimeSpan time = (data.ContainsKey("time")) ? data.GetValue("time").Value<TimeSpan>() : null;
            var dbInstance = DatabaseLibrary.Helpers.ExerciseSetHelper_db.DeleteExerciseSet(id, date, time,
                context, out StatusResponse statusResponse);

            var instances = dbInstances?.Select(x => Convert(x)).ToList();

            if (statusResponse.StatusCode == HttpStatusCode.InternalServerError
                && !includeDetailedErrors)
                statusResponse.Message = "Something went wrong while removing the Exercise Set";

            var response = new ResponseMessage
                (
                    instances != null,
                    statusResponse.Message,
                    instances
                );
            statusCode = statusResponse.StatusCode;
            return response;
        }

        public static ResponseMessage EditExerciseSet(JObject data,
            DbContext context, out HttpStatusCode statusCode, bool includeDetailedErrors = false)
        {
            int id = (data.ContainsKey("id")) ? data.GetValue("id").Value<int>() : 0;
            DateTime date = (data.ContainsKey("date")) ? data.GetValue("date").Value<DateTime>() : DateTime.MinValue;
            TimeSpan time = (data.ContainsKey("time")) ? data.GetValue("time").Value<TimeSpan>() : null;
            int weight = (data.ContainsKey("weight")) ? data.GetValue("weight").Value<int>() : 0;
            string type = (data.ContainsKey("type")) ? data.GetValue("type").Value<string>() : null;
            int reps = (data.ContainsKey("reps")) ? data.GetValue("reps").Value<int>() : 0;
            int setNumber = (data.ContainsKey("setNumber")) ? data.GetValue("setNumber").Value<int>() : 0;
            var dbInstance = DatabaseLibrary.Helpers.ExerciseSetHelper_db.EditExerciseSet(id, date, time, weight, type, reps, setNumber,
                context, out StatusResponse statusResponse);

            var instances = dbInstances?.Select(x => Convert(x)).ToList();

            if (statusResponse.StatusCode == HttpStatusCode.InternalServerError
                && !includeDetailedErrors)
                statusResponse.Message = "Something went wrong while editting the Exercise Set";

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