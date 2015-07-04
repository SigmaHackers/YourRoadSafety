namespace YourRoadSafety.Models
{
    public class CrashData
    {
        public int Id { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int Males { get; set; }
        public int Females { get; set; }
        public int YoungDriverCount { get; set; }
        public int OldDriverCount { get; set; }
        public int DriverCount { get; set; }

        public int HeavyVehicleCount { get; set; }
        public int PassengerVehicleCount { get; set; }
        public int MotorCycleCount { get; set; }
        public bool PublicVehicleInvolved { get; set; }
        public int BicyclistCount { get; set; }
    }
}
