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
        public Client(int id, DateTime dob, string name, double weight, double height, double waistCircumference, double hipCircumference, double neckCircumference)
        {
            Id = id;
            Name = name;
            Weight = weight;
            Height = height;
            WaistCircumference = waistCircumference;
            HipCircumference = hipCircumference;
            NeckCircumference = neckCircumference;
        }

        /// <summary>
        /// Clone/Copy constructor.
        /// </summary>
        /// <param name="instance">The object to clone from.</param>
        public Client(Client instance)
            : this(instance.Id, instance.Dob, instance.Name, instance.Weight, instance.Height, instance.WaistCircumference, instance.HipCircumference, instance.NeckCircumference)
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
        /// date of birth of client
        /// </summary>
        [JsonProperty(PropertyName = "dob")]
        public DateTime Dob { get; set; }

        /// <summary>
        /// First name of the client.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

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
        /// Waist Circumference of the client
        /// </summary>
        [JsonProperty(PropertyName = "waistCircumference")]
        public double WaistCircumference { get; set; }

        /// <summary>
        /// Hip Circumference of the client
        /// </summary>
        [JsonProperty(PropertyName = "hipCircumference")]
        public double HipCircumference { get; set; }

        /// <summary>
        /// Hip Circumference of the client
        /// </summary>
        [JsonProperty(PropertyName = "neckCircumference")]
        public double NeckCircumference { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Overrides the .ToString method.
        /// </summary>
        public override string ToString()
        {
            return Name;
        }

        #endregion

    }
}