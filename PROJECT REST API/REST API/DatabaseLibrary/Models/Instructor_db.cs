using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLibrary.Models
{
    class Instructor_db
    {

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Instructor_db()
        {
        }

        /// <summary>
        /// Fields constructor.
        /// </summary>
        public Instructor_db(int id, DateTime dob, string firstName, string lastName, string trainingType, string trainingPhilosophy, string exerciseModality, int clientPopulation, string accreditation)
        {
            Id = id;
            Dob = dob;
            FirstName = firstName;
            LastName = lastName;
            TrainingType = trainingType;
            TrainingPhilosophy = trainingPhilosophy;
            ExerciseModality = exerciseModality;
            ClientPopulation = clientPopulation;
            Accreditation = accreditation;
            
        }

        #endregion

        #region Properties

        public int Id { get; set; }

        public DateTime Dob { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string TrainingType { get; set; }

        public string TrainingPhilosophy { get; set; }

        public string ExerciseModality { get; set; }

        public int ClientPopulation { get; set; }

        public string Accreditation { get; set; }
        #endregion
    }
}
