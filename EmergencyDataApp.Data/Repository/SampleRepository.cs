using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using EmergencyDataApp.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EmergencyDataApp.Data
{
    /// <summary>
    /// Sample repository reads raw JSON files containing sample data. 
    /// </summary>
    public class SampleRepository : IRepository
    {
        private readonly string _rapidApiKey;
        private readonly string _sampleDataPath;
        public SampleRepository()
        {
            Console.WriteLine("Enter RapidAPI key:");

            // This is a terrible place to request input.
            // In production, I would have this sensitive information
            // stored in a file with priveleged access that the application
            // reads from
            _rapidApiKey = Console.ReadLine();

#if DEBUG
            _sampleDataPath = Path.Combine(Environment.CurrentDirectory.Replace("Server", "Data"), "SampleData");
#else
            _sampleDataPath = Path.Combine(Environment.CurrentDirectory, "SampleData");
#endif
        }
        /// <summary>
        /// Simulate retrieving this data from a database
        /// </summary>
        /// <param name="fromDate">Start date for query</param>
        /// <param name="toDate">End date for query</param>
        public Task<IEnumerable<Emergency>> GetEmergenciesAsync(DateTime fromDate, DateTime toDate)
        {
            return Task.Run(() =>
            {
                var emergencies = new List<Emergency>();

                // Get each file in the SampleData directory and serialize it's contents
                foreach (var filePath in Directory.GetFiles(_sampleDataPath))
                {
                    var fileText = File.ReadAllText(filePath);
                    emergencies.Add(JsonConvert.DeserializeObject<Emergency>(fileText));
                }

                // Return only emergencies in date range
                return emergencies.Where(e => e.Description.EventOpened.Date >= fromDate && e.Description.EventOpened.Date <= toDate);
            });
        }

        /// <summary>
        /// Returns a combination of the emergency data with corresponding weather data
        /// </summary>
        /// <param name="fromDate">Start date for query</param>
        /// <param name="toDate">End date for query</param>
        public async Task<IEnumerable<EnhancedEmergency>> GetEnhancedEmergenciesAsync(DateTime fromDate, DateTime toDate)
        {
            var enhancedEmergencies = new List<EnhancedEmergency>();

            var emergenciesByDate = (await GetEmergenciesAsync(fromDate, toDate))
                                        .GroupBy(e => e.Description.EventOpened.Date)
                                        .ToDictionary(e => e.Key, e => e.ToList());

            // Loop over each emergency date
            foreach (var date in emergenciesByDate)
            {
                // Loop over each emergency for date
                foreach (var emergency in date.Value)
                {
                    var weathersByHour = (await GetWeatherForDateAsync(emergency.Address.Latitude, emergency.Address.Longitude, date.Key))
                            .ToDictionary(w => w.Time.Hour);

                    var weatherForHour = weathersByHour[emergency.Description.HourOfDay];
                    enhancedEmergencies.Add(new EnhancedEmergency(emergency, weatherForHour));

                    // Free Meteostat subscription only allows 3 requests every second, so let's
                    // take a short pause after each request.
                    Thread.Sleep(1000);
                }
            }

            return enhancedEmergencies;
        }

        /// <summary>
        /// Returns hourly weather data for a given date
        /// </summary>
        /// <param name="latitude">Location latitude</param>
        /// <param name="longitude">Location longitude</param>
        /// <param name="date">Date to retrieve data for</param>
        public async Task<IEnumerable<Weather>> GetWeatherForDateAsync(double latitude, double longitude, DateTime date)
        {
            string dateString = date.ToString("yyyy-MM-dd");
            JToken result;

            result = await RequestMeteoStatData($"nearby?lat={latitude}&lon={longitude}");
            string stationId = result[0]["id"].ToString();

            result = await RequestMeteoStatData($"hourly?station={stationId}&start={dateString}&end={dateString}");
            return result.ToObject<IEnumerable<Weather>>();
        }

        /// <summary>
        /// Sends a request to the Meteo API on RapidAPI
        /// </summary>
        /// <param name="route">Route for base URL</param>
        /// <returns>Resposne body</returns>
        private async Task<JToken> RequestMeteoStatData(string route)
        {
            // Prep the HTTP Client
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://meteostat.p.rapidapi.com/stations/" + route),

                Headers =
                {
                    { "x-rapidapi-host", "meteostat.p.rapidapi.com" },
                    { "x-rapidapi-key", _rapidApiKey },
                },
            };

            // Make request
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var jObject = JObject.Parse(body);
                return jObject["data"];
            }
        }
    }
}