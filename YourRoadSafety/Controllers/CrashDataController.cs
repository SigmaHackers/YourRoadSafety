using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public IEnumerable<CrashData> GetAll([FromBody] CrashDataQuery query)
        {
            if(query == null)
                query = new CrashDataQuery();

            IQueryable<CrashData> crashes = _crashDataContext.Crashes;
            crashes = FilterGender(crashes, query.Gender);
            crashes = FilterAgeGroup(crashes, query.AgeGroup);

            return crashes;

            //var fakeCrashData = new List<CrashDataDto>();

            //fakeCrashData.Add(new CrashDataDto());

            //fakeCrashData.Add(new CrashDataDto(-37.76008M, 144.83187M,
            //    "Intersection	BRIMBANK	METROPOLITAN NORTH WEST REGION"));
            //fakeCrashData.Add(new CrashDataDto(-37.85962M, 145.00686M,
            //    "Intersection	STONNINGTON	METROPOLITAN SOUTH EAST REGION"));
            //fakeCrashData.Add(new CrashDataDto(-37.90021M, 144.66336M,
            //    "Non-Intersection	WYNDHAM	METROPOLITAN NORTH WEST REGION"));
            //fakeCrashData.Add(new CrashDataDto(-37.88893M, 144.76104M,
            //    "Non-Intersection	WYNDHAM	METROPOLITAN NORTH WEST REGION"));
            //fakeCrashData.Add(new CrashDataDto(-37.72999M, 145.10734M,
            //    "Non-Intersection	BANYULE	METROPOLITAN NORTH WEST REGION"));
            //fakeCrashData.Add(new CrashDataDto(-37.98584M, 145.19256M,
            //    "Non-Intersection	DANDENONG	METROPOLITAN SOUTH EAST REGION"));
            //return fakeCrashData;


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
    }
}
