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
        public static Dietician_db Add(DateTime dob, string name, string practice, string doctorate, string bachelorsDegree, string associateDegree, string certification,
            DbContext context, out StatusResponse statusResponse)
        {
            try
            {
                //validate
                if (string.IsNullOrEmpty(name?.Trim()))
                    throw new StatusException(HttpStatusCode.BadRequest, "Please provide a name.");

                //Generate a new instance
                Dietician_db instance = new Dietician_db
                    (
                        id: Convert.ToInt32(Guid.NewGuid()),
                        dob, name,
                        practice, doctorate,
                        bachelorsDegree, associateDegree,
                        certification
                        );

                int rowsAffected = context.ExecuteNonQueryCommand
                    (
                        commandText: "BEGIN; INSERT INTO dietician (dieticianId, practice, doctorate, bachelors_degree, associate_degree, certification/diploma) values (@id, @practice, @doctorate, @bachelors_degree, @associate_degree, @certification); INSERT INTO user (userId, name, DoB) values (@id, @name, @dob); COMMIT;",
                        parameters: new Dictionary<string, object>()
                        {
                            { "@id", instance.Id },
                            { "@dob", instance.Dob },
                            { "@name", instance.Name },
                            { "@practice", instance.Practice },
                            { "@doctorate", instance.Doctorate },
                            { "@bachelors_degree", instance.BachelorsDegree },
                            { "@associates_degree", instance.AssociatesDegree },
                            { "@certification", instance.Certification }
                        },
                        message: out string message
                    );
                if (rowsAffected == -1)
                    throw new Exception(message);

                // Return value
                statusResponse = new StatusResponse("Dietician added successfully");
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
                        commandText: "SELECT * FROM dietician NATURAL JOIN user",
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
                                name: row["name"].ToString(),
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
        public static Dietician_db GetDietician(int id,
            DbContext context, out StatusResponse statusResponse)
        {
            try
            {
                // Get from database
                DataTable table = context.ExecuteDataQueryCommand
                    (
                        commandText: "SELECT * FROM dietician NATURAL JOIN user WHERE dieticianId = @id",
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
                            name: row["name"].ToString(),
                            practice: row["practice"].ToString(),
                            doctorate: row["doctorate"].ToString(),
                            bachelorsDegree: row["bachelors_degree"].ToString(),
                            associatesDegree: row["associates_degree"].ToString(),
                            certification: row["certification"].ToString()
                    );

                // Return value
                statusResponse = new StatusResponse("Dietician has been retrieved successfully.");
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
        public static Dietician_db DeleteDietician(int id,
            DbContext context, out StatusResponse statusResponse)
        {

            // Delete from database
            DataTable table = context.ExecuteDataQueryCommand
                (
                    commandText: "BEGIN; DELETE * FROM dietician WHERE dieticianId = @id; DELETE * FROM user WHERE userId = @id; COMMIT;",
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

        public static CardioLog_db EditDietician(int id, DateTime dob, string name, string practice, string doctorate, string bachelorsDegree, string associateDegree, string certification,
            DbContext context, out StatusResponse statusResponse)
        {
            try
            {
                // Edit from database
                DataTable table = context.ExecuteDataQueryCommand
                    (
                        commandText: "BEGIN; UPDATE dietician SET practice = @practice, doctorate = @doctorate, bachelors_degree = @bachelors, associate_degree = @associate, certification = @certification WHERE  dieticianId = @id; UPDATE user SET DoB = @dob, name = @name WHERE  userId = @id; COMMIT;",
                        parameters: new Dictionary<string, object>()
                        {
                            { "@id", id },
                            { "@dob", dob },
                            { "@name", name },
                            { "@practice", practice },
                            { "@doctorate", doctorate },
                            { "@bachelors_degree", bachelorsDegree },
                            { "@associates_degree", associateDegree },
                            { "@certification", certification },
                        },
                        message: out string message
                    );
                statusResponse = new StatusResponse("Dietician has been edited successfully.");
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