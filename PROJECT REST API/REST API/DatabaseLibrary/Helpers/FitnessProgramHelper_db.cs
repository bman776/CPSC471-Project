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
    public class FitnessProgramHelper_db
    {
        /// <summary>
        /// Adds a new instance into the database.
        /// </summary>
        public static FitnessProgram_db Add(int id, string name, string description, string routine, DateTime creationDate, string video, string type, string modality,
            DbContext context, out StatusResponse statusResponse)
        {
            try
            {
                if (id == 0)
                    throw new StatusException(HttpStatusCode.BadRequest, "Please provide an id.");
                if (string.IsNullOrEmpty(name?.Trim()))
                    throw new StatusException(HttpStatusCode.BadRequest, "Please provide a name.");
                if (string.IsNullOrEmpty(routine?.Trim()))
                    throw new StatusException(HttpStatusCode.BadRequest, "Please provide a routine.");
                if (string.IsNullOrEmpty(type?.Trim()))
                    throw new StatusException(HttpStatusCode.BadRequest, "Please provide a type.");
                if (creationDate == DateTime.MinValue)
                    throw new StatusException(HttpStatusCode.BadRequest, "Please provide a valid date");

                //Generate a new instance
                FitnessProgram_db instance = new FitnessProgram_db
                (
                    id, name, description, routine, creationDate, video, type, modality
                );

                //Add to database
                int rowsAffected = context.ExecuteNonQueryCommand
                    (
                        commandText: "INSERT INTO fitness_prgrm (instructor_authorId, name, description, routine, creation_date, inst_vid, training_type, exercise_modality) values (@id, @name, @description, @routine, @creation_date, @video, @type, @modality)",
                        parameters: new Dictionary<string, object>()
                        {
                            { "@id", instance.Id },
                            { "@name", instance.Name },
                            { "@description", instance.Description },
                            { "@routine", instance.Routine },
                            { "@creation_date", instance.CreationDate },
                            { "@video", instance.Video},
                            { "@type", instance.Type },
                            { "@modality", instance.Modality }
                        },
                        message: out string message
                    );
                if (rowsAffected == -1)
                    throw new Exception(message);

                //Return value
                statusResponse = new StatusResponse("Fitness Program added successfully");
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
        public static List<FitnessProgram_db> GetCollection(
            DbContext context, out StatusResponse statusResponse)
        {
            try
            {
                // Get from database
                DataTable table = context.ExecuteDataQueryCommand
                    (
                        commandText: "SELECT * FROM fitness_prgrm",
                        parameters: new Dictionary<string, object>()
                        {

                        },
                        message: out string message
                    );
                if (table == null)
                    throw new Exception(message);

                //Parse data
                List<FitnessProgram_db> instances = new List<FitnessProgram_db>();
                foreach (DataRow row in table.Rows)
                    instances.Add(new FitnessProgram_db
                        (
                            id: Convert.ToInt32(row["instructor_authorId"]),
                            name: row["name"].ToString(),
                            description: row["description"].ToString(),
                            routine: row["routine"].ToString(),
                            creationDate: Convert.ToDateTime(row["creation_date"]),
                            video: row["inst_vid"].ToString(),
                            type: row["training_type"].ToString(),
                            modality: row["exercise_modality"].ToString()
                        )
                    );

                //return value
                statusResponse = new StatusResponse("Fitness Programs list has been retrieved successfully");
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
        public static FitnessProgram_db GetFitnessProgram(int id, string name,
            DbContext context, out StatusResponse statusResponse)
        {
            try
            {
                //Get from database
                DataTable table = context.ExecuteDataQueryCommand
                    (
                        commandText: "SELECT * FROM fitness_prgrm WHERE instructor_authorId = @id, name = @name",
                        parameters: new Dictionary<string, object>()
                        {
                            { "@id", id },
                            { "@name", name }
                        },
                        message: out string message
                    );

                if (table == null)
                    throw new Exception(message);

                //Parse data
                FitnessProgram_db instance = new FitnessProgram_db();
                foreach (DataRow row in table.Rows)
                    instance = new FitnessProgram_db
                        (
                            id: Convert.ToInt32(row["instructor_authorId"]),
                            name: row["name"].ToString(),
                            description: row["description"].ToString(),
                            routine: row["routine"].ToString(),
                            creationDate: Convert.ToDateTime(row["creation_date"]),
                            video: row["inst_vid"].ToString(),
                            type: row["training_type"].ToString(),
                            modality: row["exercise_modality"].ToString()
                        );

                //Return value
                statusResponse = new StatusResponse("Fitness Program successfully retrieved");
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
        public static FitnessProgram_db DeleteFitnessProgram(int id, string name,
            DbContext context, out StatusResponse statusResponse)
        {
            try
            {
                // Delete from database
                DataTable table = context.ExecuteDataQueryCommand
                    (
                        commandText: "DELETE * FROM fitness_prgrm WHERE instructor_authorId = @id, name = @name",
                        parameters: new Dictionary<string, object>()
                        {
                            { "@id", id },
                            { "@name", name }
                        },
                        message: out string message
                    );
                statusResponse = new StatusResponse("Fitness Program has been removed successfully.");
                return null;
            }
            catch (Exception exception)
            {
                statusResponse = new StatusResponse(exception);
                return null;
            }
        }

        public static FitnessProgram_db EditFitnessProgram(int id, string name, string description, string routine, DateTime creationDate, string video, string type, string modality,
            DbContext context, out StatusResponse statusResponse)
        {
            try
            {
                // Edit from database
                DataTable table = context.ExecuteDataQueryCommand
                    (
                        commandText: "UPDATE fitness_prgrm SET description = @description, routine = @routine, creation_date = @creation_date, inst_vid = @video, training_type = @type, exercise_modality = @modality WHERE  instructor_authorId = @id, name = @name",
                        parameters: new Dictionary<string, object>()
                        {
                            { "@id", id },
                            { "@name", name },
                            { "@description", description },
                            { "@routine", routine },
                            { "@creation_date", creationDate },
                            { "@video", video},
                            { "@type", type },
                            { "@modality", modality }
                        },
                        message: out string message
                    );
                statusResponse = new StatusResponse("Fitness Program has been editted successfully.");
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