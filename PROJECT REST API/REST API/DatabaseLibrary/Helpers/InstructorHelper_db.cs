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
    class InstructorHelper_db
    {

        /// <summary>
        /// Adds a new instance into the database.
        /// </summary>
        public static Instructor_db Add(DateTime dob, string firstName, string lastName, string trainingType,
            string trainingPhilosophy, string exerciseModality, int clientPopulation, string accreditation,
            DbContext context, out StatusResponse statusResponse)
        {
            try
            {
                if (string.IsNullOrEmpty(firstName?.Trim()))
                    throw new StatusException(HttpStatusCode.BadRequest, "Please provide a first name.");
                if (string.IsNullOrEmpty(lastName?.Trim()))
                    throw new StatusException(HttpStatusCode.BadRequest, "Please provide a last name.");

                //Generate a new instance
                Instructor_db instance = new Instructor_db
                    (
                        id: Convert.ToInt32(Guid.NewGuid()),
                        dob,
                        firstName, lastName,
                        trainingType, trainingPhilosophy,
                        exerciseModality, clientPopulation,
                        accreditation
                    );

                //Add to database
                int rowsAffected = context.ExecuteNonQueryCommand
                    (
                        commandText: "INSERT INTO instructors (id, dob, first_name, last_name, training_type, training_philosophy, exercise_modality, client_population, accreditation) values (@id, @dob, @first_name, @last_name, @training_type, @training_philosophy, @exercise_modality, @client_population, @accreditation)",
                        parameters: new Dictionary<string, object>()
                        {
                            { "@id", instance.Id },
                            { "@dob", instance.Dob },
                            { "@first_name", instance.FirstName },
                            { "@last_name", instance.LastName },
                            { "@training_type", instance.TrainingType },
                            { "@training_philosophy", instance.TrainingPhilosophy },
                            { "@exercise_modality", instance.ExerciseModality },
                            { "@client_population", instance.ClientPopulation },
                            { "@accreditation", instance.Accreditation }
                        },
                        message: out string message
                    );
                if (rowsAffected == -1)
                    throw new Exception(message);

                //Return value
                statusResponse = new StatusResponse("Instructor added successfully");
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
        public static List<Instructor_db> GetCollection (
            DbContext context, out StatusResponse statusResponse)
        {
            try
            {
                // Get from database
                DataTable table = context.ExecuteDataQueryCommand
                    (
                        commandText: "SELECT * FROM instructors",
                        parameters: new Dictionary<string, object>()
                        {

                        },
                        message: out string message
                    );
                if (table == null)
                    throw new Exception(message);

                // Parse data
                List<Instructor_db> instances = new List<Instructor_db>();
                foreach (DataRow row in table.Rows)
                    instances.Add(new Instructor_db
                            (
                                id: Convert.ToInt32(row["id"]),
                                dob: Convert.ToDateTime(row["dob"]),
                                firstName: row["first_name"].ToString(),
                                lastName: row["last_name"].ToString(),
                                trainingType: row["training_type"].ToString(),
                                trainingPhilosophy: row["training_philosophy"].ToString(),
                                exerciseModality: row["exercise_modality"].ToString(),
                                clientPopulation: Convert.ToInt32(row["client_population"]),
                                accreditation: row["accreditation"].ToString()
                            )
                        );

                // Return value
                statusResponse = new StatusResponse("Instructors list has been retrieved successfully.");
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
        public static Instructor_db GetInstructor(int id,
            DbContext context, out StatusResponse statusResponse)
        {
            try
            {
                // Get from database
                DataTable table = context.ExecuteDataQueryCommand
                    (
                        commandText: "SELECT * FROM instructors WHERE id = @id",
                        parameters: new Dictionary<string, object>()
                        {
                            { "@id", id },
                        },
                        message: out string message
                    );
                if (table == null)
                    throw new Exception(message);

                // Parse data
                Instructor_db instances = new Instructor_db();
                foreach (DataRow row in table.Rows)
                    instances = new Instructor_db
                        (
                            id: Convert.ToInt32(row["id"]),
                            dob: Convert.ToDateTime(row["dob"]),
                            firstName: row["first_name"].ToString(),
                            lastName: row["last_name"].ToString(),
                            trainingType: row["trainingType"].ToString(),
                            trainingPhilosophy: row["trainingPhilosophy"].ToString(),
                            exerciseModality: row["exerciseModality"].ToString(),
                            clientPopulation: Convert.ToInt32(row["clientPopulation"]),
                            accreditation : row["last_name"].ToString()
                        );

                // Return value
                statusResponse = new StatusResponse("Instructor has been retrieved successfully.");
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
        public static Instructor_db DeleteInstructor(int id,
            DbContext context, out StatusResponse statusResponse)
        {

            // Delete from database
            DataTable table = context.ExecuteDataQueryCommand
                (
                    commandText: "DELETE * FROM instructors WHERE id = @id",
                    parameters: new Dictionary<string, object>()
                    {
                            { "@id", id },
                    },
                    message: out string message
                );
            try
            {
                statusResponse = new StatusResponse("Instructor has been removed successfully.");
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
