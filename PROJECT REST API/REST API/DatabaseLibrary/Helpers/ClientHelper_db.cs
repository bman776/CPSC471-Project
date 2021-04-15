﻿using DatabaseLibrary.Core;
using DatabaseLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Net;
using System.Text;

namespace DatabaseLibrary.Helpers
{
    public class ClientHelper_db
    {

        /// <summary>
        /// Adds a new instance into the database.
        /// </summary>
        public static Client_db Add(DateTime dob, string firstName, string lastName, double weight, double height, double waistCircumference, double hipCircumference, double neckCircumference,
            DbContext context, out StatusResponse statusResponse)
        {
            try
            {
                // Validate
                if (string.IsNullOrEmpty(firstName?.Trim()))
                    throw new StatusException(HttpStatusCode.BadRequest, "Please provide a first name.");
                if (string.IsNullOrEmpty(lastName?.Trim()))
                    throw new StatusException(HttpStatusCode.BadRequest, "Please provide a last name.");

                // Generate a new instance
                Client_db instance = new Client_db
                    (
                        id: Convert.ToInt32(Guid.NewGuid()), //This can be ignored is PK in your DB is auto increment
                        dob,
                        firstName, lastName,
                        weight, height,
                        waistCircumference, hipCircumference, neckCircumference
                    );

                // Add to database
                int rowsAffected = context.ExecuteNonQueryCommand
                    (
                        commandText: "INSERT INTO clients (id, dob, first_name, last_name, weight, height, waistCircumference, hipCircumference, neckCircumference) values (@id, @dob, @first_name, @last_name, @weight, @height, @waist_circumference, @hip_circumference, @neck_circumference)",
                        parameters: new Dictionary<string, object>()
                        {
                            { "@id", instance.Id },
                            { "@dob", instance.Dob },
                            { "@first_name", instance.FirstName },
                            { "@last_name", instance.LastName },
                            { "@weight", instance.Weight },
                            { "@height", instance.Height },
                            { "@waist_circumference", instance.WaistCircumference },
                            { "@hip_circumference", instance.HipCircumference },
                            { "@neck_circumference", instance.NeckCircumference }
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
        public static List<Client_db> GetCollection(
            DbContext context, out StatusResponse statusResponse)
        {
            try
            {
                // Get from database
                DataTable table = context.ExecuteDataQueryCommand
                    (
                        commandText: "SELECT * FROM clients",
                        parameters: new Dictionary<string, object>()
                        {

                        },
                        message: out string message
                    );
                if (table == null)
                    throw new Exception(message);

                // Parse data
                List<Client_db> instances = new List<Client_db>();
                foreach (DataRow row in table.Rows)
                    instances.Add(new Client_db
                            (
                                id: Convert.ToInt32(row["id"]),
                                dob: Convert.ToDateTime(row["dob"]),
                                firstName: row["first_name"].ToString(), 
                                lastName: row["last_name"].ToString(),
                                weight: Convert.ToDouble(row["weight"]),
                                height: Convert.ToDouble(row["height"]),
                                waistCircumference: Convert.ToDouble(row["waist_circumference"]),
                                hipCircumference: Convert.ToDouble(row["hip_circumference"]),
                                neckCircumference: Convert.ToDouble(row["neck_circumference"])
                            )
                        );

                // Return value
                statusResponse = new StatusResponse("Clients list has been retrieved successfully.");
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
        public static Client_db GetClient( int id,
            DbContext context, out StatusResponse statusResponse)
        {
            try
            {
                // Get from database
                DataTable table = context.ExecuteDataQueryCommand
                    (
                        commandText: "SELECT * FROM clients WHERE id = @id",
                        parameters: new Dictionary<string, object>()
                        {
                            { "@id", id },
                        },
                        message: out string message
                    );
                if (table == null)
                    throw new Exception(message);

                // Parse data
                Client_db instances = new Client_db();
                foreach (DataRow row in table.Rows)
                        instances = new Client_db (
                                id: Convert.ToInt32(row["id"]),
                                dob: Convert.ToDateTime(row["dob"]),
                                firstName: row["first_name"].ToString(),
                                lastName: row["last_name"].ToString(),
                                weight: Convert.ToDouble(row["weight"]),
                                height: Convert.ToDouble(row["height"]),
                                waistCircumference: Convert.ToDouble(row["waist_circumference"]),
                                hipCircumference: Convert.ToDouble(row["hip_circumference"]),
                                neckCircumference: Convert.ToDouble(row["neck_circumference"])
                        );

                // Return value
                statusResponse = new StatusResponse("Clients list has been retrieved successfully.");
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
        public static Client_db DeleteClient(int id,
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
                statusResponse = new StatusResponse("Client has been removed successfully.");
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