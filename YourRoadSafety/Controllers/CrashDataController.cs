using System.Collections.Generic;
using System.Web.Http;
using YourRoadSafety.DTOs;

namespace YourRoadSafety.Controllers
{
    public class CrashDataController : ApiController
    {
        public IEnumerable<CrashDataDto> GetAll([FromBody] CrashDataQuery query)
        {
            var fakeCrashData = new List<CrashDataDto>();

            fakeCrashData.Add(new CrashDataDto());

            fakeCrashData.Add(new CrashDataDto(-37.76008M, 144.83187M,
                "Intersection	BRIMBANK	METROPOLITAN NORTH WEST REGION"));
            fakeCrashData.Add(new CrashDataDto(-37.85962M, 145.00686M,
                "Intersection	STONNINGTON	METROPOLITAN SOUTH EAST REGION"));
            fakeCrashData.Add(new CrashDataDto(-37.90021M, 144.66336M,
                "Non-Intersection	WYNDHAM	METROPOLITAN NORTH WEST REGION"));
            fakeCrashData.Add(new CrashDataDto(-37.88893M, 144.76104M,
                "Non-Intersection	WYNDHAM	METROPOLITAN NORTH WEST REGION"));
            fakeCrashData.Add(new CrashDataDto(-37.72999M, 145.10734M,
                "Non-Intersection	BANYULE	METROPOLITAN NORTH WEST REGION"));
            fakeCrashData.Add(new CrashDataDto(-37.98584M, 145.19256M,
                "Non-Intersection	DANDENONG	METROPOLITAN SOUTH EAST REGION"));
            return fakeCrashData;
        }
    }
}
