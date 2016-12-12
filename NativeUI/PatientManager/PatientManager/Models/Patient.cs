using Newtonsoft.Json;
using System;

namespace PatientManager.Common
{
    public class Patient : TableData
    {

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }

        [JsonProperty("weight")]
        public string Weight { get; set; }

        [JsonProperty("bloodType")]
        public string BloodType { get; set; }

        [JsonProperty("bloodPressure")]
        public string BloodPressure { get; set; }

        [JsonIgnore]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }
}

