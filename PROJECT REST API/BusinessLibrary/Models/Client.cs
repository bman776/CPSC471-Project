using System;
using Newtonsoft.Json;

namespace BusinessLibrary.Models
{
    public class Client
    {

        #region Constructors
        public Client()
        {

        }

        public Client(string id, string firstName, string lastName, double weight, double height, double cv, double bfp)
        {

        }

        public Client(Client instance)
            : this(instance.Id, instance.FirstName, instance.LastName, instance.Weight, instance.Height, instance.CV, instance.BFP)
        {
        }

        #endregion

        #region Properties

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "firstname")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastname")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "weight")]
        public double Weight { get; set; }

        [JsonProperty(PropertyName = "height")]
        public double Height { get; set; }

        [JsonProperty(PropertyName = "cv")]
        public double CV { get; set; }

        [JsonProperty(PropertyName = "bfp")]
        public double BFP { get; set; }

        [JsonProperty(PropertyName = "fullname")]
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }

        #endregion

        public override string ToString()
        {
            return FullName;
        }

    }
}
