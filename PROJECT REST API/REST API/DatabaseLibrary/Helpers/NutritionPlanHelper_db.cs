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
    public class NNutritionPlanHelper_db
    {
        /// <summary>
        /// Adds a new instance into the database.
        /// </summary>
        public static NutritionPlan_db Add(int id, string name, string description, string groceryList, string mealPlan,
            DbContext context, out StatusResponse statusResponse)
        {
            try
            {
                if (id == 0)
                    throw new StatusException(HttpStatusCode.BadRequest, "Please provide a valid id");
                if (string.IsNullOrEmpty(name?.Trim()))
                    throw new StatusException(HttpStatusCode.BadRequest, "Please provide a valid name");
                if (string.IsNullOrEmpty(description?.Trim()))
                    throw new StatusException(HttpStatusCode.BadRequest, "Please provide a valid description");

                //Generate a new instance
                NutritionPlan_db instance = new NutritionPlan_db
                (
                    id, name, description, groceryList, mealPlan
                );

                //Add to database
                int rowsAffected = context.ExecuteNonQueryCommand
                    (
                        commandText: "INSERT INTO nutritionPlans (id, name, description, grocery_list, meal_plan) values (@id, @name, @description, @grocery_list, @meal_plan)",
                        parameters: new Dictionary<string, object>()
                        {
                            { "@id", instance.Id },
                            { "@name", instance.Name },
                            { "@description", instance.Description },
                            { "@grocery_list", instance.GroceryList },
                            { "@meal_plan", instance.MealPlan },
                        },
                        message: out string message
                    );
                if (rowsAffected == -1)
                    throw new Exception(message);

                //Return value
                statusResponse = new StatusResponse("Nutrition Plan added successfully");
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
        public static List<NutritionPlan_db> GetCollection(
            DbContext context, out StatusResponse statusResponse)
        {
            try
            {
                // Get from database
                DataTable table = context.ExecuteDataQueryCommand
                    (
                        commandText: "SELECT * FROM nutritionPlans",
                        parameters: new Dictionary<string, object>()
                        {

                        },
                        message: out string message
                    );
                if (table == null)
                    throw new Exception(message);

                //Parse data
                List<NutritionPlan_db> instances = new List<NutritionPlan_db>();
                foreach (DataRow row in table.Rows)
                    instances.Add(new NutritionPlan_db
                        (
                            id: Convert.ToInt32(row["id"]),
                            name: row["name"].ToString(),
                            description: row["description"].ToString(),
                            groceryList: row["grocery_list"].ToString(),
                            mealPlan: row["meal_plan"].ToString()
                        )
                    );

                //return value
                statusResponse = new StatusResponse("Nutrition Plans list has been retrieved successfully");
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
        public static NutritionPlan_db GetNutritionPlan(int id, string name,
            DbContext context, out StatusResponse statusResponse)
        {
            try
            {
                //Get from database
                DataTable table = context.ExecuteDataQueryCommand
                    (
                        commandText: "SELECT * FROM nutritionPlans WHERE id = @id, name = @name",
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
                NutritionPlan_db instance = new NutritionPlan_db();
                foreach (DataRow row in table.Rows)
                    instance = new NutritionPlan_db
                        (
                            id: Convert.ToInt32(row["id"]),
                            name: row["name"].ToString(),
                            description: row["description"].ToString(),
                            groceryList: row["grocery_list"].ToString(),
                            mealPlan: row["meal_plan"].ToString()
                        );

                //Return value
                statusResponse = new StatusResponse("Nutrition Plan successfully retrieved");
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
        public static NutritionPlan_db DeleteNutrionPlan(int id, string name,
            DbContext context, out StatusResponse statusResponse)
        {
            try
            {
                // Delete from database
                DataTable table = context.ExecuteDataQueryCommand
                    (
                        commandText: "DELETE * FROM nutritionPlans WHERE id = @id, name = @name",
                        parameters: new Dictionary<string, object>()
                        {
                            { "@id", id },
                            { "@name", name }
                        },
                        message: out string message
                    );
                statusResponse = new StatusResponse("Nutrition Plan has been removed successfully.");
                return null;
            }
            catch (Exception exception)
            {
                statusResponse = new StatusResponse(exception);
                return null;
            }
        }

        public static NutritionPlan_db EditCardioLog(int id, string name, string description, string groceryList, string mealPlan,
            DbContext context, out StatusResponse statusResponse)
        {
            try
            {
                // Edit from database
                DataTable table = context.ExecuteDataQueryCommand
                    (
                        commandText: "UPDATE nutritionPlans SET name = @name, description = @description, grocery_list = @grocery_list, meal_plan = @meal_plan WHERE  id = @id",
                        parameters: new Dictionary<string, object>()
                        {
                            { "@id", id },
                            { "@name", name },
                            { "@description", description },
                            { "@grocery_list", groceryList },
                            { "@meal_plan", mealPlan },
                        },
                        message: out string message
                    );
                statusResponse = new StatusResponse("Nutrition Plan has been removed successfully.");
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