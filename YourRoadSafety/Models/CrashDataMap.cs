using System.Data.Entity.ModelConfiguration;

namespace YourRoadSafety.Models
{
    public class CrashDataMap : EntityTypeConfiguration<CrashData>
    {
        public CrashDataMap()
        {
            ToTable("CrashData");
            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("OBJECTID");
            Property(x => x.Latitude).HasColumnName("LATITUDE");
            Property(x => x.Longitude).HasColumnName("LONGITUDE");
            Property(x => x.AccidentDate).HasColumnName("ACCIDENT_DATE");
            Property(x => x.YoungDriverCount).HasColumnName("YOUNG_DRIVER");
            Property(x => x.OldDriverCount).HasColumnName("OLD_DRIVER");
            Property(x => x.DriverCount).HasColumnName("DRIVER");
            Property(x => x.HeavyVehicleCount).HasColumnName("HEAVYVEHICLE");
            Property(x => x.PassengerVehicleCount).HasColumnName("PASSENGERVEHICLE"); 
            Property(x => x.MotorCycleCount).HasColumnName("MOTORCYCLE");
            Property(x => x.PublicVehicleInvolved).HasColumnName("PUBLICVEHICLE");
            Property(x => x.BicyclistCount).HasColumnName("BICYCLIST");
        }
    }
}
