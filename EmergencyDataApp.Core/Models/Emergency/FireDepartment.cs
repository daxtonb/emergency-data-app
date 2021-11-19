using Newtonsoft.Json;

namespace EmergencyDataApp.Core
{
    /// <summary>
    /// Fire department assigned to emergency
    /// </summary>
    public class FireDepartment
    {
        /// <summary>
        /// Fire department unique identifier
        /// </summary>
        [JsonProperty("fd_id")]
        public string Id { get; set; }

        /// <summary>
        /// Fire Cares identifier
        /// </summary>
        [JsonProperty("firecares_id")]
        public string FireCaresId { get; set; }

        /// <summary>
        /// Fire departnment name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Responding shift
        /// </summary>
        [JsonProperty("shift")]
        public string Shift { get; set; }

        /// <summary>
        /// Fire department location state
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }

        /// <summary>
        /// Fire department location time zone
        /// </summary>
        /// <value></value>
        [JsonProperty("timezone")]
        public string TimeZone { get; set; }
    }
}