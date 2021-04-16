using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLibrary.Models
{
    public class NutritionPlan_db
    {
        #region Constructors
        public NutritionPlan_db()
        {
        }

        public NutritionPlan_db(int id, string name, string description, string groceryList, string mealPlan)
        {
            Id = id;
            Name = name;
            Description = description;
            GroceryList = groceryList;
            MealPlan = mealPlan;
        }

        #endregion

        #region Properties

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string GroceryList { get; set; }

        public string MealPlan { get; set; }

        #endregion
    }
}