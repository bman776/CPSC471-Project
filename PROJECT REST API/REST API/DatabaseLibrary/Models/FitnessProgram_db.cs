using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLibrary.Models
{
    public class FitnessProgram_db
    {
		#region Constructors
		public FitnessProgram_db()
		{
		}

		/// <summary>
		/// Fields constructor.
		/// </summary>
		public FitnessProgram_db(int id, string name, string description, string routine, DateTime creationDate, string video, string type, string modality)
		{
			Id = id;
			Name = name;
			Description = description;
			Routine = routine;
			CreationDate = creationDate;
			Video = video;
			Type = type;
			Modality = modality;
		}

		#endregion

		#region Properties

		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public string Routine { get; set; }

		public DateTime CreationDate { get; set; }

		public string Video { get; set; }

		public string Type { get; set; }
		public string Modality { get; set; }

		#endregion
	}
}