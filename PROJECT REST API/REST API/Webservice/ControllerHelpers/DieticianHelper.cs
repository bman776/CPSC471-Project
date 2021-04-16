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
    public class DieticianHelper
    {

        #region Converters

        /// <summary>
        /// Converts database models to a business logic object.
        /// </summary>
        public static BusinessLibrary.Models.Dietician Convert(Dietician_db instance)
        {
            if (instance == null)
                return null;
            return new BusinessLibrary.Models.Dietician(instance.Id, instance.Dob, instance.Name, instance.Practice, instance.Doctorate, instance.BachelorsDegree, instance.AssociatesDegree, instance.Certification);
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
            DateTime dob = (data.ContainsKey("dob")) ? data.GetValue("dob").Value<DateTime>() : DateTime.MinValue;
            string name = (data.ContainsKey("name")) ? data.GetValue("name").Value<string>() : null;
            string practice = (data.ContainsKey("practice")) ? data.GetValue("practice").Value<string>() : null;
            string doctorate = (data.ContainsKey("doctorate")) ? data.GetValue("doctorate").Value<string>() : null;
            string bachelorsDegree = (data.ContainsKey("bachelorsDegree")) ? data.GetValue("bachelorsDegree").Value<string>() : null;
            string associatesDegree = (data.ContainsKey("associatesDegree")) ? data.GetValue("associatesDegree").Value<string>() : null;
            string certification = (data.ContainsKey("certification")) ? data.GetValue("certification").Value<string>() : null;

            // Add instance to database
            var dbInstance = DatabaseLibrary.Helpers.DieticianHelper_db.Add(dob, name, practice, doctorate, bachelorsDegree, associatesDegree, certification,
                context, out StatusResponse statusResponse);

            // Get rid of detailed internal server error message (when requested)
            if (statusResponse.StatusCode == HttpStatusCode.InternalServerError
                && !includeDetailedErrors)
                statusResponse.Message = "Something went wrong while adding a new dietician.";

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
            var dbInstances = DatabaseLibrary.Helpers.DieticianHelper_db.GetCollection(
                context, out StatusResponse statusResponse);

            // Convert to business logic objects
            var instances = dbInstances?.Select(x => Convert(x)).ToList();

            // Get rid of detailed error message (when requested)
            if (statusResponse.StatusCode == HttpStatusCode.InternalServerError
                && !includeDetailedErrors)
                statusResponse.Message = "Something went wrong while retrieving the dieticians";

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

        public static ResponseMessage GetDietician(JObject data,
            DbContext context, out HttpStatusCode statusCode, bool includeDetailedErrors = false)
        {
            int id = (data.ContainsKey("id")) ? data.GetValue("id").Value<int>() : 0;
            var dbInstance = DatabaseLibrary.Helpers.DieticianHelper_db.GetDietician(id,
                context, out StatusResponse statusResponse);

            var instances = dbInstances?.Select(x => Convert(x)).ToList();

            if (statusResponse.StatusCode == HttpStatusCode.InternalServerError
                && !includeDetailedErrors)
                statusResponse.Message = "Something went wrong while retrieving the dietician";

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

        public static ResponseMessage RemoveDietician(JObject data,
            DbContext context, out HttpStatusCode statusCode, bool includeDetailedErrors = false)
        {

            int id = (data.ContainsKey("id")) ? data.GetValue("id").Value<int>() : 0;
            var dbInstance = DatabaseLibrary.Helpers.DieticianHelper_db.DeleteDietician(id,
                context, out StatusResponse statusResponse);

            var instances = dbInstances?.Select(x => Convert(x)).ToList();

            if (statusResponse.StatusCode == HttpStatusCode.InternalServerError
                && !includeDetailedErrors)
                statusResponse.Message = "Something went wrong while removing the dietician";

            var response = new ResponseMessage
                (
                    instances != null,
                    statusResponse.Message,
                    instances
                );
            statusCode = statusResponse.StatusCode;
            return response;
        }

        public static ResponseMessage EditDietician(JObject data,
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
            var dbInstance = DatabaseLibrary.Helpers.DieticianHelper_db.EditDietician(id, dob, name, practice, doctorate, bachelorsDegree, associatesDegree, certification,
                context, out StatusResponse statusResponse);

            var instances = dbInstances?.Select(x => Convert(x)).ToList();

            if (statusResponse.StatusCode == HttpStatusCode.InternalServerError
                && !includeDetailedErrors)
                statusResponse.Message = "Something went wrong while editting the dietician";

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