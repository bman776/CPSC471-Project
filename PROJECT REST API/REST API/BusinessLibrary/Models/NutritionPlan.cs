using Nest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLibrary.Models
{
	public class NutritionPlan
	{
		#region Constructors

		public NutritionPlan()
        {
        }

		public NutritionPlan(int id, string name, string description, string groceryList, string mealPlan)
        {
			Id = id;
			Name = name;
			Description = description;
			GroceryList = groceryList;
			MealPlan = mealPlan;
        }

		public NutritionPlan(NutritionPlan instance)
			: this(instance.Id, instance.Name, instance.Description, instance.GroceryList, instance.MealPlan)
        {
        }

		#endregion

		#region Properties

		[JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "description")]
		public string Description { get; set; }

		[JsonProperty(PropertyName = "groceryList")]
		public string GroceryList { get; set; }

		[JsonProperty(PropertyName = "mealPlan")]
		public string MealPlan { get; set; }

		#endregion

		#region Methods

		#endregion
	}
}