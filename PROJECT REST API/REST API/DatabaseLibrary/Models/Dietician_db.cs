using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLibrary.Models
{
    public class Dietician_db
    {

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Dietician_db()
        {
        }

        /// <summary>
        /// Fields constructor.
        /// </summary>
        public Dietician_db(int id, DateTime dob, string firstName, string lastName, string practice, string doctorate, string bachelorsDegree, string associatesDegree, string certification)
        {
            Id = id;
            Dob = dob;
            FirstName = firstName;
            LastName = lastName;
            Practice = practice;
            Doctorate = doctorate;
            BachelorsDegree = bachelorsDegree;
            AssociatesDegree = associatesDegree;
            Certification = certification;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Id generated by our system upon creation of a new instance.
        /// </summary>
        public int Id { get; set; }

        public DateTime Dob { get; set; }

        /// <summary>
        /// First name used of the client.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name used of the client.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Weight of the client.
        /// </summary>
        public string Practice { get; set; }

        /// <summary>
        /// Height of the client.
        /// </summary>
        public string Doctorate { get; set; }

        /// <summary>
        /// Waist Circumference of the client.
        /// </summary>
        public string BachelorsDegree { get; set; }

        /// <summary>
        /// Hip Circumference of the client.
        /// </summary>
        public string AssociatesDegree { get; set; }

        /// <summary>
        /// Neck Circumference of the client.
        /// </summary>
        public string Certification { get; set; }

        #endregion

    }
}
