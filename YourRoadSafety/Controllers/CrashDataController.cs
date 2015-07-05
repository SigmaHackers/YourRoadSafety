using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using YourRoadSafety.DTOs;
using YourRoadSafety.Models;

namespace YourRoadSafety.Controllers
{
    public class CrashDataController : ApiController
    {
        private readonly CrashDataContext _crashDataContext;

        public CrashDataController()
        {
            _crashDataContext = new CrashDataContext();
        }

        public IEnumerable<CrashData> GetAll([FromUri] CrashDataQuery query)
        {
            if(query == null)
                query = new CrashDataQuery();

            IQueryable<CrashData> crashes = _crashDataContext.Crashes;
            crashes = FilterGender(crashes, query.Gender);
            crashes = FilterAgeGroup(crashes, query.AgeGroup);
            crashes = FilterVehicleType(crashes, query.VehicleType);

            return crashes;
        }

        [Route("api/ChartData")]
        public ChartDataDto GetChartData([FromUri] CrashDataQuery query)
        {
            if (query == null)
                query = new CrashDataQuery();

            IQueryable<CrashData> crashes = _crashDataContext.Crashes;
            crashes = FilterGender(crashes, query.Gender);
            crashes = FilterAgeGroup(crashes, query.AgeGroup);
            crashes = FilterVehicleType(crashes, query.VehicleType);

            var crashesList = crashes.ToList();

            var chartData = new ChartDataDto();

            return chartData;
        }

        private IQueryable<CrashData> FilterGender(IQueryable<CrashData> crashes, Gender gender)
        {
            switch (gender)
            {
                case Gender.Unknown:
                    break;
                case Gender.Male:
                    crashes = crashes.Where(x => x.Males > 0);
                    break;
                case Gender.Female:
                    crashes = crashes.Where(x => x.Females > 0);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("gender", gender, null);
            }

            return crashes;
        }

        private IQueryable<CrashData> FilterAgeGroup(IQueryable<CrashData> crashes, AgeGroup ageGroup)
        {
            switch (ageGroup)
            {
                case AgeGroup.Unknown:
                    break;
                case AgeGroup.Young:
                    crashes = crashes.Where(x => x.YoungDriverCount > 0);
                    break;
                case AgeGroup.MiddleAge:
                    crashes = crashes.Where(x => x.DriverCount > x.YoungDriverCount + x.OldDriverCount);
                    break;
                case AgeGroup.Old:
                    crashes = crashes.Where(x => x.OldDriverCount > 0);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("ageGroup", ageGroup, null);
            }

            return crashes;
        }

        private IQueryable<CrashData> FilterVehicleType(IQueryable<CrashData> crashes, VehicleType vehicleType)
        {
            switch (vehicleType)
            {
                case VehicleType.Unknown:
                    break;
                case VehicleType.Car:
                    crashes = crashes.Where(x => x.PassengerVehicleCount > 0);
                    break;
                case VehicleType.MotorBike:
                    crashes = crashes.Where(x => x.MotorCycleCount > 0);
                    break;
                case VehicleType.Bicycle:
                    crashes = crashes.Where(x => x.BicyclistCount > 0);
                    break;
                case VehicleType.Other:
                    crashes = crashes.Where(x => x.PublicVehicleInvolved || x.HeavyVehicleCount > 0);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("vehicleType", vehicleType, null);
            }

            return crashes;
        }
    }
}
