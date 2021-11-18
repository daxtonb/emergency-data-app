using System;
using Newtonsoft.Json;

namespace EmergencyDataApp.Core
{
    /// <summary>
    /// Details about emergency
    /// </summary>
    public class Description
    {
        /// <summary>
        /// Comments detailing emergency
        /// </summary>
        [JsonProperty("comments")]
        public string Comments { get; set; }

        /// <summary>
        /// Day of the week emergency occurred
        /// </summary>
        [JsonProperty("day_of_week")]
        public string DayOfWeek { get; set; }

        /// <summary>
        /// Date-time when event opened
        /// </summary>
        [JsonProperty("event_opened")]
        public DateTime EventOpened { get; set; }

        /// <summary>
        /// Date-time when event closed
        /// </summary>
        [JsonProperty("event_closed")]
        public DateTime? EventClosed { get; set; }

        /// <summary>
        /// Evebt unique identifier
        /// </summary>
        [JsonProperty("event_id")]
        public string EventId { get; set; }

        /// <summary>
        /// Amplifying time data for event
        /// </summary>
        [JsonProperty("event_data")]
        public ExtendedData EventData { get; set; }

        /// <summary>
        /// Date-time of first unit's arrival
        /// </summary>
        /// <value></value>
        [JsonProperty("first_unit_arrived")]
        public DateTime? FirstUnitArrived { get; set; }

        /// <summary>
        /// Date-time of first unit's dispatch
        /// </summary>
        [JsonProperty("first_unit_dispatched")]
        public DateTime? FirstUnitDispatch { get; set; }

        /// <summary>
        /// Date-time of first unit's departure
        /// </summary>
        /// <value></value>
        [JsonProperty("first_unit_enroute")]
        public DateTime? FirstUnitEnroute { get; set; }

        /// <summary>
        /// Hour of day of incident
        /// </summary>
        public short HourOfDay { get; set; }

        /// <summary>
        /// Unique identifier for incident
        /// </summary>
        [JsonProperty("incident_number")]
        public string IncidentNumber { get; set; }

        /// <summary>
        /// Date-time of LOI search completion
        /// </summary>
        [JsonProperty("loi_search_complete")]
        public DateTime? LoiSearchComplete { get; set; }

        /// <summary>
        /// Subtype of emergency
        /// </summary>
        [JsonProperty("subtype")]
        public string Subtype { get; set; }

        /// <summary>
        /// Type of emergency
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}