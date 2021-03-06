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
    public class ExerciseSetHelper_db
    {

        /// <summary>
        /// Adds a new instance into the database.
        /// </summary>
        public static ExerciseSet_db Add(int id, DateTime date, TimeSpan time, int weight, string type, int reps, int setNumber,
            DbContext context, out StatusResponse statusResponse)
        {
            try
            {
                if (id == 0)
                    throw new StatusException(HttpStatusCode.BadRequest, "Please provide a valid id");
                if (date == DateTime.MinValue)
                    throw new StatusException(HttpStatusCode.BadRequest, "Please provide a valid date");
                if (time == TimeSpan.Zero)
                    throw new StatusException(HttpStatusCode.BadRequest, "Please provide a valid duration");

                //Generate a new instance
                ExerciseSet_db instance = new ExerciseSet_db
                (
                    id, date, time, weight, type, reps, setNumber
                );

                //Add to database
                int rowsAffected = context.ExecuteNonQueryCommand
                    (
                        commandText: "INSERT INTO exercise_set (clientId, workoutLog_date, workoutLog_time, type, set_number, reps, weight) values (@id, @date, @time, @type, @set_number, @reps, @weight",
                        parameters: new Dictionary<string, object>()
                        {
                        { "@id", instance.Id },
                        { "@date", instance.Date },
                        { "@time", instance.Time },
                        { "@weight", instance.Weight },
                        { "@type", instance.Type },
                        { "@reps", instance.Reps },
                        { "@set_number", instance.SetNumber },
                        },
                        message: out string message
                    );

                if (rowsAffected == -1)
                    throw new Exception(message);

                //Return value
                statusResponse = new StatusResponse("Exercise Set added successfully");
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
        public static List<ExerciseSet_db> GetCollection (
            DbContext context, out StatusResponse statusResponse)
        {
            try
            {
                //Get from database
                DataTable table = context.ExecuteDataQueryCommand
                    (
                        commandText: "SELECT * FROM exercise_set",
                        parameters: new Dictionary<string, object>()
                        {

                        },
                        message: out string message
                    );
                if (table == null)
                    throw new Exception(message);

                //Parse Data
                List<ExerciseSet_db> instances = new List<ExerciseSet_db>();
                foreach (DataRow row in table.Rows)
                    instances.Add(new ExerciseSet_db
                        (
                            id: Convert.ToInt32(row["id"]),
                            date: Convert.ToDateTime(row["date"]),
                            time: TimeSpan.Parse(row["time"].ToString()),
                            weight: Convert.ToInt32(row["weight"]),
                            type: row["type"].ToString(),
                            reps: Convert.ToInt32(row["reps"]),
                            setNumber: Convert.ToInt32(row["set_number"])
                        )
                    );

                //Return value
                statusResponse = new StatusResponse("Exercise Sets list has been retrieved successfully");
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
        public static ExerciseSet_db GetExerciseSet(int id, DateTime date, TimeSpan time,
            DbContext context, out StatusResponse statusResponse)
        {
            try
            {
                //Get from database
                DataTable table = context.ExecuteDataQueryCommand
                    (
                        commandText: "SELECT * FROM exercise_set WHERE clientId = @id, workoutLog_date = @date, workoutLog_time = @time",
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

                //Parse Data
                ExerciseSet_db instance = new ExerciseSet_db();
                foreach (DataRow row in table.Rows)
                    instance = new ExerciseSet_db
                        (
                            id: Convert.ToInt32(row["id"]),
                            date: Convert.ToDateTime(row["date"]),
                            time: TimeSpan.Parse(row["time"].ToString()),
                            weight: Convert.ToInt32(row["weight"]),
                            type: row["type"].ToString(),
                            reps: Convert.ToInt32(row["reps"]),
                            setNumber: Convert.ToInt32(row["set_number"])
                        );

                //Return value
                statusResponse = new StatusResponse("Exercise Set successfully retrieved");
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
        public static ExerciseSet_db DeleteExerciseSet(int id, DateTime date, TimeSpan time,
            DbContext context, out StatusResponse statusResponse)
        {
            try
            {
                // Delete from database
                DataTable table = context.ExecuteDataQueryCommand
                    (
                        commandText: "DELETE * FROM exercise_set WHERE clientId = @id, workoutLog_date = @date, workouLog_time = @time",
                        parameters: new Dictionary<string, object>()
                        {
                            { "@id", id },
                            { "@date", date },
                            { "@time", time }
                        },
                        message: out string message
                    );
                statusResponse = new StatusResponse("Exercise Set has been removed successfully.");
                return null;
            }
            catch (Exception exception)
            {
                statusResponse = new StatusResponse(exception);
                return null;
            }
        }

        public static CardioLog_db EditExerciseSet(int id, DateTime date, TimeSpan time, int type, string setNumber, int reps, int weight,
            DbContext context, out StatusResponse statusResponse)
        {
            try
            {
                // Edit from database
                DataTable table = context.ExecuteDataQueryCommand
                    (
                        commandText: "UPDATE exercise_set SET type = @type, set_number = @sets, reps = @reps, weight = @weight WHERE  clientId = @id, workoutLog_date = @date, workoutLog_time = @time",
                        parameters: new Dictionary<string, object>()
                        {
                            { "@id", id },
                            { "@date", date },
                            { "@time", time },
                            { "@type", type },
                            { "@sets", setNumber },
                            { "@reps", reps },
                            { "@weight", weight }
                        },
                        message: out string message
                    );
                statusResponse = new StatusResponse("Exercise Set has been edited successfully.");
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