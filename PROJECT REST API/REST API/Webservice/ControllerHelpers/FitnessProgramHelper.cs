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
    public class FitnessProgramHelper
    {
        #region Converters

        /// <summary>
        /// Converts database models to a business logic object.
        /// </summary>
        public static BusinessLibrary.Models.FitnessProgram Convert(FitnessProgram_db instance)
        {
            if (instance == null)
                return null;
            return new BusinessLibrary.Models.FitnessProgram(instance.Id, instance.Name, instance.Description, instance.Routine, instance.CreationDate, instance.Video, instance.Type, instance.Modality);
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
            DateTime creationDate = (data.ContainsKey("creationDate")) ? data.GetValue("creationDate").Value<DateTime>() : DateTime.MinValue;
            string name = (data.ContainsKey("name")) ? data.GetValue("name").Value<string>() : null;
            int id = (data.ContainsKey("id")) ? data.GetValue("id").Value<int>() : null;
            string routine = (data.ContainsKey("routine")) ? data.GetValue("routine").Value<string>() : null;
            string description = (data.ContainsKey("description")) ? data.GetValue("description").Value<string>() : null;
            string video = (data.ContainsKey("video")) ? data.GetValue("video").Value<string>() : null;
            string type = (data.ContainsKey("type")) ? data.GetValue("type").Value<string>() : null;
            string modality = (data.ContainsKey("modality")) ? data.GetValue("modality").Value<string>() : null;

            // Add instance to database
            var dbInstance = DatabaseLibrary.Helpers.FitnessProgramHelper_db.Add(id, name, description, routine, creationDate, video, type, modality,
                context, out StatusResponse statusResponse);

            // Get rid of detailed internal server error message (when requested)
            if (statusResponse.StatusCode == HttpStatusCode.InternalServerError
                && !includeDetailedErrors)
                statusResponse.Message = "Something went wrong while adding a new FitnessProgram.";

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
            var dbInstances = DatabaseLibrary.Helpers.FitnessProgramHelper_db.GetCollection(
                context, out StatusResponse statusResponse);

            // Convert to business logic objects
            var instances = dbInstances?.Select(x => Convert(x)).ToList();

            // Get rid of detailed error message (when requested)
            if (statusResponse.StatusCode == HttpStatusCode.InternalServerError
                && !includeDetailedErrors)
                statusResponse.Message = "Something went wrong while retrieving the FitnessPrograms";

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

        public static ResponseMessage GetFitnessProgram(JObject data,
            DbContext context, out HttpStatusCode statusCode, bool includeDetailedErrors = false)
        {
            int id = (data.ContainsKey("id")) ? data.GetValue("id").Value<int>() : 0;
            var dbInstance = DatabaseLibrary.Helpers.FitnessProgramHelper_db.GetFitnessProgram(id,
                context, out StatusResponse statusResponse);

            var instances = dbInstances?.Select(x => Convert(x)).ToList();

            if (statusResponse.StatusCode == HttpStatusCode.InternalServerError
                && !includeDetailedErrors)
                statusResponse.Message = "Something went wrong while retrieving the FitnessProgram";

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

        public static ResponseMessage RemoveFitnessProgram(JObject data,
            DbContext context, out HttpStatusCode statusCode, bool includeDetailedErrors = false)
        {

            int id = (data.ContainsKey("id")) ? data.GetValue("id").Value<int>() : 0;
            var dbInstance = DatabaseLibrary.Helpers.FitnessProgramHelper_db.DeleteFitnessProgram(id,
                context, out StatusResponse statusResponse);

            var instances = dbInstances?.Select(x => Convert(x)).ToList();

            if (statusResponse.StatusCode == HttpStatusCode.InternalServerError
                && !includeDetailedErrors)
                statusResponse.Message = "Something went wrong while removing the FitnessProgram";

            var response = new ResponseMessage
                (
                    instances != null,
                    statusResponse.Message,
                    instances
                );
            statusCode = statusResponse.StatusCode;
            return response;
        }

        public static ResponseMessage EditFitnessProgram(JObject data,
            DbContext context, out HttpStatusCode statusCode, bool includeDetailedErrors = false)
        {
            int id = (data.ContainsKey("id")) ? data.GetValue("id").Value<int>() : 0;
            DateTime dob = (data.ContainsKey("dob")) ? data.GetValue("dob").Value<DateTime>() : DateTime.MinValue;
            string name = (data.ContainsKey("name")) ? data.GetValue("name").Value<string>() : null;
            string practice = (data.ContainsKey("practice")) ? data.GetValue("practice").Value<string>() : null;
            string doctorate = (data.ContainsKey("doctorate")) ? data.GetValue("doctorate").Value<string>() : null;
            string bachelorsDegree = (data.ContainsKey("bachelorsDegree")) ? data.GetValue("bachelorsDegree").Value<string>() : null;
            string associatesDegree = (data.ContainsKey("associatesDegree")) ? data.GetValue("associatesDegree").Value<string>() : null;
            string certification = (data.ContainsKey("certification")) ? data.GetValue("certification").Value<string>() : null;
            var dbInstance = DatabaseLibrary.Helpers.FitnessProgramHelper_db.EditFitnessProgram(id, dob, name, practice, doctorate, bachelorsDegree, associatesDegree, certification,
                context, out StatusResponse statusResponse);

            var instances = dbInstances?.Select(x => Convert(x)).ToList();

            if (statusResponse.StatusCode == HttpStatusCode.InternalServerError
                && !includeDetailedErrors)
                statusResponse.Message = "Something went wrong while editting the FitnessProgram";

            var response = new ResponseMessage
                (
                    instances != null,
                    statusResponse.Message,
                    instancesd
                );
            statusCode = statusResponse.StatusCode;
            return response;
        }
    }
}