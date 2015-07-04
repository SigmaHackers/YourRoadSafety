namespace YourRoadSafety.DTOs
{
    public class CrashDataDto
    {
        public CrashDataDto()
        {
            
        }

        public CrashDataDto(decimal latitude, decimal longitude, string title)
        {
            Latitude = latitude;
            Longitude = longitude;
            Title = title;
        }

        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Title { get; set; }
    }
}
