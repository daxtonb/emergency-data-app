using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace EmergencyDataApp.Core
{
    /// <summary>
    /// Contains data concerning response units
    /// </summary>
    public class Apparatus
    {
        /// <summary>
        /// Unique identifer for response unit vehicle
        /// </summary>
        [JsonProperty("car_id")]
        public string CarId { get; set; }

        /// <summary>
        /// Key time durations for response unit
        /// </summary>
        [JsonProperty("extended_data")]
        public ExtendedData ExtendedData { get; set; }

        /// <summary>
        /// Geo hash of response unit
        /// </summary>
        [JsonProperty("geohash")]
        public string GeoHash { get; set; }

        /// <summary>
        /// Personnel comprising response unit
        /// </summary>
        [JsonProperty("personnel")]
        public IEnumerable<Person> Personnel { get; set; }

        /// <summary>
        /// Shift of responding unit
        /// </summary>
        /// <value></value>
        [JsonProperty("shift")]
        public char Shift { get; set; }

        /// <summary>
        /// Unique identifer of responding unit's station
        /// </summary>
        [JsonProperty("station")]
        public string Station { get; set; }

        /// <summary>
        /// Unique identifer of unit
        /// </summary>
        [JsonProperty("unit_id")]
        public string UnitId { get; set; }


        /// <summary>
        /// Member of response unit (no data in example JSON files to model this after)
        /// </summary>
        public class Person { }
        /// <summary>
        /// Geographical and time data for a unit's event
        /// </summary>
        public class UnitData
        {
            /// <summary>
            /// Geo Hash for location
            /// </summary>
            [JsonProperty("geohash")]
            public string GeoHash { get; set; }

            /// <summary>
            /// Location latitude
            /// </summary>
            [JsonProperty("latitude")]
            public double Latitude { get; set; }

            /// <summary>
            /// Location longitude
            /// </summary>
            [JsonProperty("longitude")]
            public double Longitude { get; set; }

            /// <summary>
            /// Date-time stamp of event
            /// </summary>
            public DateTime TimeStamp { get; set; }
        }
    }
}