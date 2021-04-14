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
    public class ClientHelper
    {

        #region Converters

        /// <summary>
        /// Converts database models to a business logic object.
        /// </summary>
        public static BusinessLibrary.Models.Client Convert(Client_db instance)
        {
            if (instance == null)
                return null;
            return new BusinessLibrary.Models.Client(instance.Id, instance.FirstName, instance.LastName);
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
            string firstName = (data.ContainsKey("firstName")) ? data.GetValue("firstName").Value<string>() : null;
            string lastName = (data.ContainsKey("lastName")) ? data.GetValue("lastName").Value<string>() : null;
            double weight = (data.ContainsKey("weight")) ? data.GetValue("weight").Value<double>() : 0.0;
            double height = (data.ContainsKey("height")) ? data.GetValue("weight").Value<double>() : 0.0;
            double cv = (data.ContainsKey("cv")) ? data.GetValue("cv").Value<double>() : 0.0;
            double bfp = (data.ContainsKey("bfp")) ? data.GetValue("bfp").Value<double>() : 0.0;

            // Add instance to database
            var dbInstance = DatabaseLibrary.Helpers.ClientHelper_db.Add(firstName, lastName, weight, height, cv, bfp,
                context, out StatusResponse statusResponse);

            // Get rid of detailed internal server error message (when requested)
            if (statusResponse.StatusCode == HttpStatusCode.InternalServerError
                && !includeDetailedErrors)
                statusResponse.Message = "Something went wrong while adding a new client.";

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
            var dbInstances = DatabaseLibrary.Helpers.ClientHelper_db.GetCollection(
                context, out StatusResponse statusResponse);

            // Convert to business logic objects
            var instances = dbInstances?.Select(x => Convert(x)).ToList();

            // Get rid of detailed error message (when requested)
            if (statusResponse.StatusCode == HttpStatusCode.InternalServerError
                && !includeDetailedErrors)
                statusResponse.Message = "Something went wrong while retrieving the client";

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

    }
}
