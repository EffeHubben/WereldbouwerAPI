using System.ComponentModel.DataAnnotations;

namespace WereldbouwerAPI
{
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        [Required]
        [MinLength(1)] [MaxLength(100)]
        public string? Summary { get; set; }
    }
}
