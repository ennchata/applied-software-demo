namespace AP.DemoProject.WebApp.Models
{
    public class CityCreateDTO
    {
        public string Name { get; set; } = string.Empty;
        public int Population { get; set; }
        public int CountryId { get; set; }
    }
}