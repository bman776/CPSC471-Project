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
        public static CardioLog_db Add(int id, DateTime date, TimeSpan duration, int caloriesBurned, string exerciseType,
            DbContext context, out StatusResponse statusResponse)
        {
            try
            {
                if (id == 0)
                    throw new StatusException(HttpStatusCode.BadRequest, "Please provide a valid id");
                if (date == DateTime.MinValue)
                    throw new StatusException(HttpStatusCode.BadRequest, "Please provide a valid date");
                if (duration == TimeSpan.Zero)
                    throw new StatusException(HttpStatusCode.BadRequest, "Please provide a valid duration");

                //Generate a new instance
                CardioLog_db instance = new CardioLog_db
                (
                    id, date, duration, caloriesBurned, exerciseType
                );

                //Add to database
                int rowsAffected = context.ExecuteNonQueryCommand
                    (
                        commandText: "INSERT INTO cardioLogs (id, date, duration, calories_burned, exercise_type) values (@id, @date, @duration, @calories_burned, @exercise_type)",
                        parameters: new Dictionary<string, object>()
                        {
                            { "@id", instance.Id },
                            { "@date", instance.LogDate },
                            { "@time", instance.Time },
                            { "@calories_burned", instance.CaloriesBurned },
                            { "@exercise_type", instance.CardioType },
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
        public static List<CardioLog_db> GetCollection(
            DbContext context, out StatusResponse statusResponse)
        {
            try
            {
                // Get from database
                DataTable table = context.ExecuteDataQueryCommand
                    (
                        commandText: "SELECT * FROM cardioLogs",
                        parameters: new Dictionary<string, object>()
                        {

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
                            logDate: Convert.ToDateTime(row["date"]),
                            time: TimeSpan.Parse(row["time"].ToString()),
                            caloriesBurned: Convert.ToInt32(row["calories_burned"]),
                            cardioType: row["exercise_type"].ToString()
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
                            logDate: Convert.ToDateTime(row["date"]),
                            time: TimeSpan.Parse(row["time"].ToString()),
                            caloriesBurned: Convert.ToInt32(row["calories_burned"]),
                            cardioType: row["exercise_type"].ToString()
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
        public static CardioLog_db DeleteCardioLog(int id, DateTime date, TimeSpan time,
            DbContext context, out StatusResponse statusResponse)
        {
            try
            {
                // Delete from database
                DataTable table = context.ExecuteDataQueryCommand
                    (
                        commandText: "DELETE * FROM cardioLogs WHERE id = @id, date = @date, time = @time",
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

        public static CardioLog_db EditCardioLog(int id, DateTime date, TimeSpan duration, int caloriesBurned, string exerciseType,
            DbContext context, out StatusResponse statusResponse)
        {
            try
            {
                // Edit from database
                DataTable table = context.ExecuteDataQueryCommand
                    (
                        commandText: "UPDATE cardioLogs SET date = @date, time = @time, calories_burned = @calories_burned, exercise_type = @exercise_type WHERE  id = @id, date = @date, time = @time",
                        parameters: new Dictionary<string, object>()
                        {
                            { "@id", id },
                            { "@date", date },
                            { "@time", duration },
                            { "@calories_burned", caloriesBurned },
                            { "@exercise_type", exerciseType },
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
    }
}