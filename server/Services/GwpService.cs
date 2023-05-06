using server.Models;
using System.Net;

namespace server.Services
{
    public class GwpService : IGwpService
    {
        private readonly IStaticDataService _staticDataService;
        public GwpService(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }
        public async Task<List<Dictionary<string, Double>>> GetAvgGrossPremium(GwpRequest request)
        {
            var res = _staticDataService.GetGwpCsvData();
            var result = new List<Dictionary<string, Double>>();
            var dataByCountry = res.Where(i => i.country == request.Country);
            if (!dataByCountry.Any())
            {
                throw new BadHttpRequestException("Country Code Doesn't Exist", (int)HttpStatusCode.BadRequest);
            }
            foreach (var lineOfBusiness in request.LineOfBusiness)
            {
                var dict = new Dictionary<string, Double>();
                var sum = _staticDataService.GetSumofPremium(dataByCountry.FirstOrDefault(i => i.lineOfBusiness == lineOfBusiness), lineOfBusiness);
                var avg = sum / 16;
                dict.Add(lineOfBusiness, avg);
                result.Add(dict);
            }

            return result;
        }
    }
}
