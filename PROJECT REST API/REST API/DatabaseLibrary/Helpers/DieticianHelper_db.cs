using DatabaseLibrary.Core;
using DatabaseLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Net;
using System.Text;

namespace DatabaseLibrary.Helpers
{
    public class DieticianHelper_db
    {
        /// <summary>
        /// Adds a new instance into the database.
        /// </summary>
        public static Dietician_db Add(DateTime dob, string firstName, string lastName, string practice, string doctorate, string bachelorsDegree, string associateDegree, string certification,
            DbContext context, out StatusResponse statusResponse)
        {
            try
            {
                //validate
                if (string.IsNullOrEmpty(firstName?.Trim()))
                    throw new StatusException(HttpStatusCode.BadRequest, "Please provide a first name.");
                if (string.IsNullOrEmpty(lastName?.Trim()))
                    throw new StatusException(HttpStatusCode.BadRequest, "Please provide a last name.");

                //Generate a new instance
                Dietician_db instance = new Dietician_db
                    (
                        id: Convert.ToInt32(Guid.NewGuid()),
                        dob,
                        firstName, lastName,
                        practice, doctorate,
                        bachelorsDegree, associateDegree,
                        certification
                        );

                int rowsAffected = context.ExecuteNonQueryCommand
                    (
                        commandText: "INSERT INTO dieticians (id, dob, first_name, last_name, practice, doctorate, bachelors_degree, associate_degree, certification) values (@id, @dob, @first_name, @last_name, @practice, @doctorate, @bachelors_degree, @associate_degree, @certification)",
                        parameters: new Dictionary<string, object>()
                        {
                            { "@id", instance.Id },
                            { "@dob", instance.Dob },
                            { "@first_name", instance.FirstName },
                            { "@last_name", instance.LastName },
                            { "@weight", instance.Practice },
                            { "@height", instance.Doctorate },
                            { "@waist_circumference", instance.BachelorsDegree },
                            { "@hip_circumference", instance.AssociatesDegree },
                            { "@neck_circumference", instance.Certification }
                        },
                        message: out string message
                    );
                if (rowsAffected == -1)
                    throw new Exception(message);

                // Return value
                statusResponse = new StatusResponse("Client added successfully");
                return instance;

            }
            catch (Exception exception)
            {
                statusResponse = new StatusResponse(exception);
                return null;
            }
        }

        /// <summary>
        /// Retrieves a list of instances.
        /// </summary>
        public static List<Dietician_db> GetCollection(
            DbContext context, out StatusResponse statusResponse)
        {
            try
            {
                // Get from database
                DataTable table = context.ExecuteDataQueryCommand
                    (
                        commandText: "SELECT * FROM dieticians",
                        parameters: new Dictionary<string, object>()
                        {

                        },
                        message: out string message
                    );
                if (table == null)
                    throw new Exception(message);

                // Parse data
                List<Dietician_db> instances = new List<Dietician_db>();
                foreach (DataRow row in table.Rows)
                    instances.Add(new Dietician_db
                            (
                                id: Convert.ToInt32(row["id"]),
                                dob: Convert.ToDateTime(row["dob"]),
                                firstName: row["first_name"].ToString(),
                                lastName: row["last_name"].ToString(),
                                practice: row["practice"].ToString(),
                                doctorate: row["doctorate"].ToString(),
                                bachelorsDegree: row["bachelors_degree"].ToString(),
                                associatesDegree: row["associates_degree"].ToString(),
                                certification: row["certification"].ToString()
                            )
                        );

                // Return value
                statusResponse = new StatusResponse("Dieticians list has been retrieved successfully.");
                return instances;
            }
            catch (Exception exception)
            {
                statusResponse = new StatusResponse(exception);
                return null;
            }
        }

        /// <summary>
        /// Retrieves specific instance
        /// </summary>
        public static Dietician_db GetClient(int id,
            DbContext context, out StatusResponse statusResponse)
        {
            try
            {
                // Get from database
                DataTable table = context.ExecuteDataQueryCommand
                    (
                        commandText: "SELECT * FROM dieticians WHERE id = @id",
                        parameters: new Dictionary<string, object>()
                        {
                            { "@id", id },
                        },
                        message: out string message
                    );
                if (table == null)
                    throw new Exception(message);

                // Parse data
                Dietician_db instances = new Dietician_db();
                foreach (DataRow row in table.Rows)
                    instances = new Dietician_db(
                            id: Convert.ToInt32(row["id"]),
                            dob: Convert.ToDateTime(row["dob"]),
                            firstName: row["first_name"].ToString(),
                            lastName: row["last_name"].ToString(),
                            practice: row["practice"].ToString(),
                            doctorate: row["doctorate"].ToString(),
                            bachelorsDegree: row["bachelors_degree"].ToString(),
                            associatesDegree: row["associates_degree"].ToString(),
                            certification: row["certification"].ToString()
                    );

                // Return value
                statusResponse = new StatusResponse("Dieticians list has been retrieved successfully.");
                return instances;
            }
            catch (Exception exception)
            {
                statusResponse = new StatusResponse(exception);
                return null;
            }
        }

        /// <summary>
        /// Deletes information of given client
        /// </summary>
        public static Dietician_db DeleteClient(int id,
            DbContext context, out StatusResponse statusResponse)
        {

            // Delete from database
            DataTable table = context.ExecuteDataQueryCommand
                (
                    commandText: "DELETE * FROM clients WHERE id = @id",
                    parameters: new Dictionary<string, object>()
                    {
                            { "@id", id },
                    },
                    message: out string message
                );
            try
            {
                statusResponse = new StatusResponse("Dietician has been removed successfully.");
                return null;
            }
            catch (Exception exception)
            {
                statusResponse = new StatusResponse(exception);
                return null;
            }
        }
    }
}