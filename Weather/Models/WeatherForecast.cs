namespace Weather.Models
{
    public class WeatherForecast
    {
        public string City { get; set; }
        public DateTime Date { get; set; }
        public string Condition { get; set; }
        public double TemperatureCelsius { get; set; }
        public int Humidity { get; set; }
        public double WindSpeedKph { get; set; }


        public WeatherForecast()
        {
                
        }

        public WeatherForecast(DateTime date,  double temperatureC, string condition)
        {
            Date = date;
            Condition = condition;
            TemperatureCelsius = temperatureC;
        }

        public override string ToString()
        {
            return $"{Date.ToShortDateString()} - {City}: {Condition}, {TemperatureCelsius}°C, " +
                   $"Humidity: {Humidity}%, Wind: {WindSpeedKph} km/h";
        }
    }
}