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
        public Instructor_db(string id, string firstName, string lastName, string trainingType, string trainingPhilosophy, string exerciseModality, int clientPopulation, string accreditation)
        {
            Id = id;
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

        public string Id { get; set; }

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
