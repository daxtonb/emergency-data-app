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

        public DataTests()
        {
            _repository = new SampleRepository();
        }

        [Fact]
        public async Task Can_get_emergency_data()
        {
            //Given
            IEnumerable<Emergency> emergencies;
            DateTime date = new DateTime(2017, 5, 15);
            //When
            emergencies = await _repository.GetEmergenciesAsync(date, date);

            //Then
            Assert.NotNull(emergencies);
            Assert.True(emergencies.Any(), "Query returned no results.");
        }
    }
}