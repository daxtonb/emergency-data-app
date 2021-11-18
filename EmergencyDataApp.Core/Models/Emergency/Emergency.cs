using Newtonsoft.Json;

namespace EmergencyDataApp.Core
{
    /// <summary>
    /// Models an emergency report
    /// </summary>
    public class Emergency
    {
        /// <summary>
        /// Address information for emergency
        /// </summary>
        [JsonProperty("address")]
        public Address Address { get; set; }

        /// <summary>
        /// Responding unit(s) details
        /// </summary>
        [JsonProperty("apparatus")]
        public Apparatus Apparatus { get; set; }

        /// <summary>
        /// Details about emergency
        /// </summary>
        /// <value></value>
        [JsonProperty("description")]
        public Description Description { get; set; }

        /// <summary>
        /// Responding fire department information
        /// </summary>
        [JsonProperty("fire_department")]
        public FireDepartment FireDepartment { get; set; }

        /// <summary>
        /// Version of API
        /// </summary>
        [JsonProperty("version")]
        public string Version { get; set; }
    }
}