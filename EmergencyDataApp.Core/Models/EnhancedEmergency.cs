namespace EmergencyDataApp.Core
{
    /// <summary>
    /// Enhanced version of Emergency containing weather data
    /// </summary>
    public class EnhancedEmergency : Emergency
    {
        /// <summary>
        /// Weather data at hour time of emergency
        /// </summary>
        public Weather Weather { get; set; }

        public EnhancedEmergency() { }

        /// In production, I would probably take the time to setup and auto mapper
        public EnhancedEmergency(Emergency emergency, Weather weather)
        {
            // In production, I would do a deep copy to keep references being shared between
            // the two objects
            foreach (var prop in typeof(Emergency).GetProperties())
            {
                prop.SetValue(this, prop.GetValue(emergency));
            }

            Weather = weather;
        }
    }
}