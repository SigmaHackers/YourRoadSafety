using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourRoadSafety.DTOs
{
    public class CrashDataQuery
    {
        public int? Age { get; set; }
        public Gender Gender { get; set; }
        public VehicleType VehicleType { get; set; }
    }
}
