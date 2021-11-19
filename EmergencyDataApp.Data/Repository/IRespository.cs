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
        /// Retreives emergencies with weather information
        /// </summary>
        /// <param name="fromDate">Filter start date</param>
        /// <param name="toDate">Filter end date</param>
        /// <returns>Collection of EnhancedEmergencies for date</returns>
        public Task<IEnumerable<EnhancedEmergency>> GetEnhancedEmergenciesAsync(DateTime fromDate, DateTime toDate);

        /// <summary>
        /// Retrieves weather information for date
        /// </summary>
        /// <param name="date">Desired weather data date</param>
        /// <returns>Collection of Weather for date</returns>
        public Task<IEnumerable<Weather>> GetWeatherForDateAsync(double lattitude, double longitude, DateTime date);
    }
}