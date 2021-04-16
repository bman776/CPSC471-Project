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
    public class SleepLogHelper_db
    {

        /// <summary>
        /// Adds a new instance into the database.
        /// </summary>
        public static SleepLog_db Add(int id, DateTime date, TimeSpan time, TimeSpan sleepDuration,
            DbContext context, out StatusResponse statusResponse)
        {
            try
            {
                if (id == 0)
                    throw new StatusException(HttpStatusCode.BadRequest, "Please provide a valid id");
                if (date == DateTime.MinValue)
                    throw new StatusException(HttpStatusCode.BadRequest, "Please provide a valid date");
                if (sleepDuration == TimeSpan.Zero)
                    throw new StatusException(HttpStatusCode.BadRequest, "Please provide a valid duration");

                //Generate a new instance
                SleepLog_db instance = new SleepLog_db
                (
                    id, date, time, sleepDuration
                );

                //Add to database
                int rowsAffected = context.ExecuteNonQueryCommand
                    (
                        commandText: "INSERT INTO sleepLogs (id, date, time, sleep_duration) values (@id, @date, @time, @sleep_duration)",
                        parameters: new Dictionary<string, object>()
                        {
                            { "@id", instance.Id },
                            { "@date", instance.Date },
                            { "@time", instance.Time },
                            { "@sleep_duration", instance.SleepDuration }
                        },
                        message: out string message
                    );
                if (rowsAffected == -1)
                    throw new Exception(message);

                //Return value
                statusResponse = new StatusResponse("Sleep Log added successfully");
                return instance;
            }
            catch (Exception exception)
            {
                statusResponse = new StatusResponse(exception);
                return null;
            }
        }

        /// <summary>
        /// Retrieves a list of instances
        /// </summary>
        public static List<SleepLog_db> GetCollection (
            DbContext context, out StatusResponse statusResponse)
        {
            try
            {
                // Get from database
                DataTable table = context.ExecuteDataQueryCommand
                    (
                        commandText: "SELECT * FROM sleepLogs",
                        parameters: new Dictionary<string, object>()
                        {

                        },
                        message: out string message
                    );
                if (table == null)
                    throw new Exception(message);

                //Parse data
                List<SleepLog_db> instances = new List<SleepLog_db>();
                foreach (DataRow row in table.Rows)
                    instances.Add(new SleepLog_db
                        (
                            id: Convert.ToInt32(row["id"]),
                            date: Convert.ToDateTime(row["date"]),
                            time: TimeSpan.Parse(row["time"].ToString()),
                            sleepDuration: TimeSpan.Parse(row["sleep_duration"].ToString())
                        )
                    );

                //return value
                statusResponse = new StatusResponse("Sleep logs list has been retrieved successfully");
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
        public static SleepLog_db GetSleepLog(int id, DateTime date, TimeSpan time,
            DbContext context, out StatusResponse statusResponse)
        {
            try
            {
                //Get from database
                DataTable table = context.ExecuteDataQueryCommand
                    (
                        commandText: "SELECT * FROM sleepLogs WHERE id = @id, date = @date, time = @time",
                        parameters: new Dictionary<string, object>()
                        {
                            { "@id", id },
                            { "@date", date },
                            { "@time", time }
                        },
                        message:out string message
                    );

                if (table == null)
                    throw new Exception(message);

                //Parse data
                SleepLog_db instance = new SleepLog_db();
                foreach (DataRow row in table.Rows)
                    instance = new SleepLog_db
                        (
                            id: Convert.ToInt32(row["id"]),
                            date: Convert.ToDateTime(row["date"]),
                            time: TimeSpan.Parse(row["time"].ToString()),
                            sleepDuration: TimeSpan.Parse(row["sleep_duration"].ToString())
                        );

                //Return value
                statusResponse = new StatusResponse("Sleep Log successfully retrieved");
                return instance;
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
        public static SleepLog_db DeleteSleepLog(int id, DateTime date, TimeSpan time,
            DbContext context, out StatusResponse statusResponse)
        {
            try
            {
                // Delete from database
                DataTable table = context.ExecuteDataQueryCommand
                    (
                        commandText: "DELETE * FROM sleepLogs WHERE id = @id, date = @date, time = @time",
                        parameters: new Dictionary<string, object>()
                        {
                            { "@id", id },
                            { "@date", date },
                            { "@time", time }
                        },
                        message: out string message
                    );
                statusResponse = new StatusResponse("Sleep Log has been removed successfully.");
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