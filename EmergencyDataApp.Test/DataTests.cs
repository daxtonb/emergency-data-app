using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmergencyDataApp.Core;
using EmergencyDataApp.Data;
using Xunit;

namespace EmergencyDataApp.Test
{
    public class DataTests
    {
        private readonly IRepository _repository;
        private readonly DateTime _defaultDate;

        public DataTests()
        {
            _repository = new SampleRepository();
            _defaultDate = new DateTime(2017, 5, 15);  // This is the date used in the sample data
        }

        [Fact]
        public async Task Can_get_emergency_data()
        {
            //Given
            IEnumerable<Emergency> emergencies;

            //When
            emergencies = await _repository.GetEmergenciesAsync(_defaultDate, _defaultDate);

            //Then
            Assert.NotNull(emergencies);
            Assert.True(emergencies.Any(), "Query returned no results.");
        }

        [Fact]
        public async Task Can_get_enhanced_emergency_data()
        {
            //Given
            IEnumerable<Emergency> emergencies;

            //When
            emergencies = await _repository.GetEnhancedEmergenciesAsync(_defaultDate, _defaultDate);

            //Then
            Assert.NotNull(emergencies);
            Assert.True(emergencies.Any(), "Query returned no results.");
        }

        [Fact]
        public async Task Can_get_weather_data()
        {
            //Given
            IEnumerable<Weather> weathers;

            //When
            weathers = await _repository.GetWeatherForDateAsync(37.541885, -77.440624, _defaultDate);

            // Then
            Assert.NotNull(weathers);
            Assert.True(weathers.Any(), "Query returned no results.");
        }
    }
}