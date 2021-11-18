using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmergencyDataApp.Core;

namespace EmergencyDataApp.Data
{
    /// <summary>
    /// Repository that connects to data source
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Retrieves emergencies from database filtered to date range
        /// </summary>
        /// <param name="fromDate">Filter start date</param>
        /// <param name="toDate">Filter end date</param>
        /// <returns>Collection of Emergencies</returns>
        public Task<IEnumerable<Emergency>> GetEmergenciesAsync(DateTime fromDate, DateTime toDate);

        /// <summary>
        /// Retrieves weather information for date
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="date"></param>
        public Task<IEnumerable<Weather>> GetWeatherAsync(DateTime date);
    }
}