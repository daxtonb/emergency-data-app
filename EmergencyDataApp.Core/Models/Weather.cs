using System;
using Newtonsoft.Json;

namespace EmergencyDataApp.Core
{
    /// <summary>
    /// Models weather for a given hour (see https://dev.meteostat.net/api/stations/hourly.html#parameters)
    /// </summary>
    public class Weather
    {
        /// <summary>
        /// Time of observation
        /// </summary>
        [JsonProperty("time")]
        public DateTime Time { get; set; }

        /// <summary>
        /// The air temperature in degrees Celsius
        /// </summary>
        [JsonProperty("temp")]
        public double Temperature { get; set; }

        /// <summary>
        /// The dew point in degrees Celsius
        /// </summary>
        [JsonProperty("dwpt")]
        public double DewPoint { get; set; }

        /// <summary>
        /// The relative humidty in percent
        /// </summary>
        [JsonProperty("rhum")]
        public int RelativeHumidty { get; set; }

        /// <summary>
        /// The one hour precipitation total in mm
        /// </summary>
        [JsonProperty("prcp")]
        public double Precipitation { get; set; }

        /// <summary>
        /// The snow depth in mm
        /// </summary>
        [JsonProperty("snow")]
        public int Snow { get; set; }

        /// <summary>
        /// The wind direction in degrees
        /// </summary>
        [JsonProperty("wdir")]
        public int WindDirection { get; set; }

        /// <summary>
        /// The average wind speed in km/h
        /// </summary>
        [JsonProperty("wspd")]
        public double WindSpeed { get; set; }

        /// <summary>
        /// The peak wind gust in km/h
        /// </summary>
        [JsonProperty("wpgt")]
        public double PeakWindGust { get; set; }

        /// <summary>
        /// The sea-level air pressure in hPa
        /// </summary>
        [JsonProperty("pres")]
        public double AirPressure { get; set; }

        /// <summary>
        /// The one hour sunshine total in minutes
        /// </summary>
        [JsonProperty("tsun")]
        public int TotalSunshine { get; set; }

        /// <summary>
        /// The weather condition code
        /// </summary>
        [JsonProperty("coco")]
        public int WeatherCondition { get; set; }
    }
}