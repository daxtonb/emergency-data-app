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
    }
}