using server.Models;

namespace server.Services
{
    public interface IStaticDataService
    {
        List<GwpCsv> GetGwpCsvData();
        Double GetSumofPremium(GwpCsv data, string lob);
    }
}
