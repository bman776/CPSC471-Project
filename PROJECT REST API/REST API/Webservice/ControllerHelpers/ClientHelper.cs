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
            return new BusinessLibrary.Models.Client(instance.Id, instance.Dob, instance.FirstName, instance.LastName, instance.Weight, instance.Height, instance.WaistCircumference, instance.HipCircumference, instance.NeckCircumference);
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
            string firstName = (data.ContainsKey("firstName")) ? data.GetValue("firstName").Value<string>() : null;
            string lastName = (data.ContainsKey("lastName")) ? data.GetValue("lastName").Value<string>() : null;
            double weight = (data.ContainsKey("weight")) ? data.GetValue("weight").Value<double>() : 0.0;
            double height = (data.ContainsKey("height")) ? data.GetValue("height").Value<double>() : 0.0;
            double waistCircumference = (data.ContainsKey("waistCircumference")) ? data.GetValue("waistCircumference").Value<double>() : 0.0;
            double hipCircumference = (data.ContainsKey("hipCircumference")) ? data.GetValue("hipCircumference").Value<double>() : 0.0;
            double neckCircumference = (data.ContainsKey("neckCircumference")) ? data.GetValue("neckCircumference").Value<double>() : 0.0;

            // Add instance to database
            var dbInstance = DatabaseLibrary.Helpers.ClientHelper_db.Add(dob, firstName, lastName, weight, height, waistCircumference, hipCircumference, neckCircumference,
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

        public static ResponseMessage GetClient(JObject data,
            DbContext context, out HttpStatusCode statusCode, bool includeDetailedErrors = false)
        {
            int id = (data.ContainsKey("id")) ? data.GetValue("id").Value<int>() : 0;
            var dbInstance = DatabaseLibrary.Helpers.ClientHelper_db.GetClient(id,
                context, out StatusResponse statusResponse);

            var instances = dbInstances?.Select(x => Convert(x)).ToList();

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

        public static ResponseMessage RemoveClient(JObject data,
            DbContext context, out HttpStatusCode statusCode, bool includeDetailedErrors = false)
        {

            int id = (data.ContainsKey("id")) ? data.GetValue("id").Value<int>() : 0;
            var dbInstance = DatabaseLibrary.Helpers.ClientHelper_db.DeleteClient(id,
                context, out StatusResponse statusResponse);

            var instances = dbInstances?.Select(x => Convert(x)).ToList();

            if (statusResponse.StatusCode == HttpStatusCode.InternalServerError
                && !includeDetailedErrors)
                statusResponse.Message = "Something went wrong while removing the client";

            var response = new ResponseMessage
                (
                    instances != null,
                    statusResponse.Message,
                    instances
                );
            statusCode = statusResponse.StatusCode;
            return response;
        }

        public static ResponseMessage EditClient(JObject data,
            DbContext context, out HttpStatusCode statusCode, bool includeDetailedErrors = false)
        {
            int id = (data.ContainsKey("id")) ? data.GetValue("id").Value<int>() : 0;
            double weight = (data.ContainsKey("weight")) ? data.GetValue("weight").Value<double>() : 0.0;
            double id = (data.ContainsKey("height")) ? data.GetValue("height").Value<double>() : 0.0;
            double id = (data.ContainsKey("waist")) ? data.GetValue("waist").Value<double>() : 0.0;
            double id = (data.ContainsKey("hip")) ? data.GetValue("hip").Value<double>() : 0.0;
            double id = (data.ContainsKey("neck")) ? data.GetValue("neck").Value<double>() : 0.0;
            var dbInstance = DatabaseLibrary.Helpers.ClientHelper_db.EditClient(id, weight, height, waist, hip, neck,
                context, out StatusResponse statusResponse);

            var instances = dbInstances?.Select(x => Convert(x)).ToList();

            if (statusResponse.StatusCode == HttpStatusCode.InternalServerError
                && !includeDetailedErrors)
                statusResponse.Message = "Something went wrong while editting the client";

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
