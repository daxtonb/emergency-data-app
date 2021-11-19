using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using EmergencyDataApp.Core;
using EmergencyDataApp.Data.Sample;
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
        public SampleRepository()
        {
            Console.WriteLine("Enter RapidAPI key:");

            // This is a terrible place to request input.
            // In production, I would have this sensitive information
            // stored in a file with priveleged access that the application
            // reads from
            _rapidApiKey = Console.ReadLine();
        }
        /// <summary>
        /// Simulate retrieving this data from a database
        /// </summary>
        public Task<IEnumerable<Emergency>> GetEmergenciesAsync(DateTime fromDate, DateTime toDate)
        {
            return Task.Run(() =>
            {
                var emergencies = JsonConvert.DeserializeObject<IEnumerable<Emergency>>(SampleEmergencies.data);

                // Return only emergencies in date range
                return emergencies.Where(e => e.Description.EventOpened.Date >= fromDate && e.Description.EventOpened.Date <= toDate);
            });
        }

        public async Task<IEnumerable<EnhancedEmergency>> GetEnhancedEmergenciesAsync(DateTime fromDate, DateTime toDate)
        {
            var enhancedEmergencies = new List<EnhancedEmergency>();

            var emergenciesByDate = (await GetEmergenciesAsync(fromDate, toDate))
                                        .GroupBy(e => e.Description.EventOpened.Date)
                                        .ToDictionary(e => e.Key, e => e.ToList());

            foreach (var date in emergenciesByDate)
            {
                foreach (var emergency in date.Value)
                {
                    var weathersByHour = (await GetWeatherForDateAsync(emergency.Address.Latitude, emergency.Address.Longitude, date.Key))
                            .ToDictionary(w => w.Time.Hour);

                    var weatherForHour = weathersByHour[emergency.Description.HourOfDay];
                    enhancedEmergencies.Add(new EnhancedEmergency(emergency, weatherForHour));

                    Thread.Sleep(3000);
                }
            }

            return enhancedEmergencies;
        }

        public async Task<IEnumerable<Weather>> GetWeatherForDateAsync(double latitude, double longitude, DateTime date)
        {
            string dateString = date.ToString("yyyy-MM-dd");
            JToken result;

            result = await RequestMeteoStatData($"nearby?lat={latitude}&lon={longitude}");
            string stationId = result[0]["id"].ToString();

            result = await RequestMeteoStatData($"hourly?station={stationId}&start={dateString}&end={dateString}");
            return result.ToObject<IEnumerable<Weather>>();
        }

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