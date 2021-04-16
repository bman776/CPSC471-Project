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
    public class CardioLogHelper_db
    {
        /// <summary>
        /// Adds a new instance into the database.
        /// </summary>
        public static CardioLog_db Add(int id, string logName, DateTime logDate, TimeSpan startTime, TimeSpan endTime, int caloriesBurned, string cardioType,
            DbContext context, out StatusResponse statusResponse)
        {
            try
            {
                if (id == 0)
                    throw new StatusException(HttpStatusCode.BadRequest, "Please provide a valid id");
                if (logDate == DateTime.MinValue)
                    throw new StatusException(HttpStatusCode.BadRequest, "Please provide a valid date");
                if (startTime == TimeSpan.Zero)
                    throw new StatusException(HttpStatusCode.BadRequest, "Please provide a valid time");
                if (endTime == TimeSpan.Zero)
                    throw new StatusException(HttpStatusCode.BadRequest, "Please provide a valid time");

                //Generate a new instance
                CardioLog_db instance = new CardioLog_db
                (
                    id, logName, logDate, startTime, endTime, caloriesBurned, cardioType
                );

                //Add to database
                int rowsAffected = context.ExecuteNonQueryCommand
                    (
                        commandText: "INSERT INTO cardio_log (clientId, log_name, log_date, cardio_type, start_time, end_time, calories_burned) values (@id, @name, @date, @type, @start, @end, @calories)",
                        parameters: new Dictionary<string, object>()
                        {
                            { "@id", instance.Id },
                            { "@name", instance.LogName },
                            { "@date", instance.LogDate },
                            { "@start", instance.StartTime },
                            { "@end", instance.EndTime },
                            { "@calories", instance.CaloriesBurned },
                            { "@type", instance.CardioType }
                        },
                        message: out string message
                    );
                if (rowsAffected == -1)
                    throw new Exception(message);

                //Return value
                statusResponse = new StatusResponse("Cardio Log added successfully");
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
        public static List<CardioLog_db> GetCollection( int id,
            DbContext context, out StatusResponse statusResponse)
        {
            try
            {
                // Get from database
                DataTable table = context.ExecuteDataQueryCommand
                    (
                        commandText: "SELECT * FROM cardio_log WHERE clientId = @id",
                        parameters: new Dictionary<string, object>()
                        {
                            { "@id", id }
                        },
                        message: out string message
                    );
                if (table == null)
                    throw new Exception(message);

                //Parse data
                List<CardioLog_db> instances = new List<CardioLog_db>();
                foreach (DataRow row in table.Rows)
                    instances.Add(new CardioLog_db
                        (
                            id: Convert.ToInt32(row["id"]),
                            logName: row["name"].ToString(),
                            logDate: Convert.ToDateTime(row["date"]),
                            startTime: TimeSpan.Parse(row["start_time"].ToString()),
                            endTime: TimeSpan.Parse(row["end_time"].ToString()),
                            caloriesBurned: Convert.ToInt32(row["calories_burned"]),
                            cardioType: row["cardio_type"].ToString()
                        )
                    );

                //return value
                statusResponse = new StatusResponse("Cardio logs list has been retrieved successfully");
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
        public static CardioLog_db GetCardioLog(int id, DateTime date, TimeSpan time,
            DbContext context, out StatusResponse statusResponse)
        {
            try
            {
                //Get from database
                DataTable table = context.ExecuteDataQueryCommand
                    (
                        commandText: "SELECT * FROM cardioLogs WHERE id = @id, date = @date, time = @time",
                        parameters: new Dictionary<string, object>()
                        {
                            { "@id", id },
                            { "@date", date },
                            { "@time", time }
                        },
                        message: out string message
                    );

                if (table == null)
                    throw new Exception(message);

                //Parse data
                CardioLog_db instance = new CardioLog_db();
                foreach (DataRow row in table.Rows)
                    instance = new CardioLog_db
                        (
                            id: Convert.ToInt32(row["id"]),
                            logName: row["name"].ToString(),
                            logDate: Convert.ToDateTime(row["date"]),
                            startTime: TimeSpan.Parse(row["start_time"].ToString()),
                            endTime: TimeSpan.Parse(row["end_time"].ToString()),
                            caloriesBurned: Convert.ToInt32(row["calories_burned"]),
                            cardioType: row["cardio_type"].ToString()
                        );

                //Return value
                statusResponse = new StatusResponse("Cardio Log successfully retrieved");
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
        public static CardioLog_db DeleteCardioLog(int id, DateTime date, TimeSpan time,
            DbContext context, out StatusResponse statusResponse)
        {
            try
            {
                // Delete from database
                DataTable table = context.ExecuteDataQueryCommand
                    (
                        commandText: "DELETE * FROM cardioLogs WHERE clientId = @id, log_date = @date, start_time = @time",
                        parameters: new Dictionary<string, object>()
                        {
                            { "@id", id },
                            { "@date", date },
                            { "@time", time }
                        },
                        message: out string message
                    );
                statusResponse = new StatusResponse("Cardio Log has been removed successfully.");
                return null;
            }
            catch (Exception exception)
            {
                statusResponse = new StatusResponse(exception);
                return null;
            }
        }

        public static CardioLog_db EditCardioLog(int id, string name, DateTime date, TimeSpan startTime, TimeSpan endTime, int caloriesBurned, string exerciseType,
            DbContext context, out StatusResponse statusResponse)
        {
            try
            {
                // Edit from database
                DataTable table = context.ExecuteDataQueryCommand
                    (
                        commandText: "UPDATE cardioLogs SET log_name = @name, end_time = @end_time, calories_burned = @calories_burned, exercise_type = @exercise_type WHERE  clientId = @id, log_date = @date, start_time = @start_time",
                        parameters: new Dictionary<string, object>()
                        {
                            { "@id", id },
                            { "@name", name },
                            { "@date", date },
                            { "@start_time", startTime },
                            { "@end_time", endTime },
                            { "@calories_burned", caloriesBurned },
                            { "@cardio_type", exerciseType },
                        },
                        message: out string message
                    );
                statusResponse = new StatusResponse("Cardio Log has been edited successfully.");
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