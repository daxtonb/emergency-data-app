using Newtonsoft.Json;

namespace EmergencyDataApp.Core
{
    /// <summary>
    /// Contains address information for an emergency
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Address unique identifier
        /// </summary>
        [JsonProperty("address_id")]
        public string Id { get; set; }

        /// <summary>
        /// First line of street address
        /// </summary>
        [JsonProperty("address_line1")]
        public string Line1 { get; set; }

        /// <summary>
        /// City of address
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// Common place name of location
        /// </summary>
        [JsonProperty("common_place_name")]
        public string CommonPlaceName { get; set; }

        /// <summary>
        /// First cross street at location
        /// </summary>
        [JsonProperty("cross_street1")]
        public string CrossStreet1 { get; set; }

        /// <summary>
        /// Second cross street at location
        /// </summary>
        [JsonProperty("cross_street2")]
        public string CrossStreet2 { get; set; }

        /// <summary>
        /// I'm not going to pretend to know what this is
        /// </summary>
        [JsonProperty("first_due")]
        public string FirstDue { get; set; }

        /// <summary>
        /// Geo Hash for location
        /// </summary>
        [JsonProperty("geohash")]
        public string GeoHash { get; set; }

        /// <summary>
        /// Latitude of location
        /// </summary>
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude of location
        /// </summary>
        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        /// <summary>
        /// Location's street name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Location's street number
        /// </summary>
        [JsonProperty("number")]
        public string Number { get; set; }

        /// <summary>
        /// Postal code of location
        /// </summary>
        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }

        /// <summary>
        /// Prefix of cardinal direction to location
        /// </summary>
        [JsonProperty("prefix_direction")]
        public string PrefixDirection { get; set; }

        /// <summary>
        /// Unique identifier of response zone
        /// </summary>
        [JsonProperty("response_zone")]
        public string ResponseZone { get; set; }

        /// <summary>
        /// Location's state in country
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }

        /// <summary>
        /// Suffix of cardinal direction to location
        /// </summary>
        [JsonProperty("suffix_direction")]
        public string SuffixDirection { get; set; }

        /// <summary>
        /// Type of location
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}