using System.Collections.Generic;

namespace YourRoadSafety.DTOs
{
    public class ChartDataDto
    {
        public List<string> Dates { get; set; }
        public List<int> NumCrashes { get; set; }
        public List<int> CausedByAlcohol { get; set; }
        public List<int> LeadToDeath { get; set; }
        public List<int> DuringNight { get; set; }
        public List<int> DuringDay { get; set; } 
    }
}
