﻿using Nest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLibrary.Models
{
    public class Client
    {

        #region Contructors

        /// <summary>
        /// Default constructor. 
        /// Need for serialization purposes.
        /// </summary>
        public Client()
        {
        }

        /// <summary>
        /// Fields constructor.
        /// </summary>
        public Client(int id, string firstName, string lastName, double weight, double height, double cv, double bfp)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Weight = weight;
            Height = height;
            Cv = cv;
            Bfp = bfp;
        }

        /// <summary>
        /// Clone/Copy constructor.
        /// </summary>
        /// <param name="instance">The object to clone from.</param>
        public Client(Client instance)
            : this(instance.Id, instance.FirstName, instance.LastName, instance.Weight, instance.Height, instance.Cv, instance.Bfp)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Id generated by our system upon creation of a new instance.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        /// <summary>
        /// First name of the client.
        /// </summary>
        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of the client.
        /// </summary>
        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        /// <summary>
        /// Weight of the client.
        /// </summary>
        [JsonProperty(PropertyName = "weight")]
        public double Weight { get; set; }

        /// <summary>
        /// Height of the client.
        /// </summary>
        [JsonProperty(PropertyName = "height")]
        public double Height { get; set; }

        /// <summary>
        /// CV of the client.
        /// </summary>
        [JsonProperty(PropertyName = "cv")]
        public double Cv { get; set; }

        /// <summary>
        /// Body Fat Percentage of the client.
        /// </summary>
        [JsonProperty(PropertyName = "bfp")]
        public double Bfp { get; set; }

        /// <summary>
        /// FUll name of the client.
        /// </summary>
        [JsonProperty(PropertyName = "fullName")]
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Overrides the .ToString method.
        /// </summary>
        public override string ToString()
        {
            return FullName;
        }

        #endregion

    }
}
