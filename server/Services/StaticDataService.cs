using server.Models;
using System.Net;

namespace server.Services
{
    public class StaticDataService : IStaticDataService
    {
        private readonly List<GwpCsv> _gwpCsvs;
        public StaticDataService(List<GwpCsv> gwpCsvs)
        {
            _gwpCsvs = gwpCsvs;

        }
        public List<GwpCsv> GetGwpCsvData()
        {
            return _gwpCsvs;
        }

        public Double GetSumofPremium(GwpCsv data, string lob)
        {
            if(data == null)
            {
                throw new BadHttpRequestException("LineOfBusiness " + lob + " Doesn't Exist", (int)HttpStatusCode.BadRequest);
            }
            Double result = 0;
            result = Double.Parse("0" + data.Y2000) + Double.Parse("0" + data.Y2001) + Double.Parse("0" + data.Y2002) + Double.Parse("0" + data.Y2003) + Double.Parse("0" + data.Y2004) +
                Double.Parse("0" + data.Y2005) + Double.Parse("0" + data.Y2006) + Double.Parse("0" + data.Y2007) + Double.Parse("0" + data.Y2008) + Double.Parse("0" + data.Y2009) +
                Double.Parse("0" + data.Y2010) + Double.Parse("0" + data.Y2011) + Double.Parse("0" + data.Y2012) + Double.Parse("0" + data.Y2013) + Double.Parse("0" + data.Y2014) +
                Double.Parse("0" + data.Y2015);

            return result;
        }
    }
}
