using Newtonsoft.Json;

namespace EmergencyDataApp.Core
{
    /// <summary>
    /// Contains amplifying information concerning key response team times
    /// </summary>
    public class ExtendedData
    {
        /// <summary>
        /// Total time in minutes to dispatch unit
        /// </summary>
        [JsonProperty("dispatch_duration")]
        public int DispatchDuration { get; set; }

        /// <summary>
        /// Total time in minutes of event
        /// </summary>
        [JsonProperty("event_duration")]
        public int EventDuration { get; set; }

        /// <summary>
        /// Total time in minutes of dispatched unit's response
        /// </summary>
        [JsonProperty("response_time")]
        public int ResponseTime { get; set; }
    }
}