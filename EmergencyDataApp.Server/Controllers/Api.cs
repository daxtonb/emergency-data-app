using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmergencyDataApp.Core;
using EmergencyDataApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace EmergencyDataApp.Server
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ApiController : Controller
    {
        private readonly IRepository _repository;

        public ApiController(IRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Returns all Emergencies within date range
        /// </summary>
        /// <param name="fromDate">From date</param>
        /// <param name="toDate">To date</param>
        [HttpGet("{fromDate}/{toDate}")]
        public async Task<IActionResult> Emergency(DateTime fromDate, DateTime toDate)
            => Ok(await _repository.GetEmergenciesAsync(fromDate, toDate));

        /// <summary>
        /// Returns weather for all hours of date
        /// </summary>
        /// <param name="date">Date</param>
        [HttpGet("{latitude}/{longitude}/{date}")]
        public async Task<IActionResult> Weather(double latitude, double longitude, DateTime date)
            => Ok(await _repository.GetWeatherForDateAsync(latitude, longitude, date));

        /// <summary>
        /// Returns all emergencies with weather information for date
        /// </summary>
        /// <param name="fromDate">From date</param>
        /// <param name="toDate">To date</param>
        /// <returns></returns>
        [HttpGet("{fromDate}/{toDate}")]
        public async Task<IActionResult> EnhancedEmergency(DateTime fromDate, DateTime toDate)
            => Ok(await _repository.GetEnhancedEmergenciesAsync(fromDate, toDate));
    }
}