using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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
        /// <summary>
        /// Simulate retrieving this data from a database
        /// </summary>
        public Task<IEnumerable<Emergency>> GetEmergenciesAsync(DateTime fromDate, DateTime toDate)
        {
            return Task.Run(() =>
            {
                var emergencies = JsonConvert.DeserializeObject<IEnumerable<Emergency>>(SampleEmergencies.data);

                // Return only emergencies in date range
                return emergencies.Where(e => e.Description.EventOpened.Date >= fromDate && e.Description.EventOpened <= toDate);
            });
        }

        public async Task<IEnumerable<Weather>> GetWeatherAsync(DateTime date)
        {
            // For production, this sensitive information would be read from a file with priveleged access
            Console.WriteLine("Enter RapidAPI Key:");
            string apiKey = Console.ReadLine();
            string dateString = date.ToString("yyyy-MM-dd");

            // Prep the HTTP Client
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://meteostat.p.rapidapi.com/stations/hourly?station=10637&start={dateString}&end={dateString}"),

                Headers =
                {
                    { "x-rapidapi-host", "meteostat.p.rapidapi.com" },
                    { "x-rapidapi-key", apiKey },
                },
            };

            // Make request
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var jObject = JObject.Parse(body);
                return jObject["data"].ToObject<IEnumerable<Weather>>();
            }
        }
    }
}