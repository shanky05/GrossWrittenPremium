using server.Models;

namespace server.Services
{
    public interface IGwpService
    {
        Task<List<Dictionary<string, Double>>> GetAvgGrossPremium(GwpRequest request);
    }
}
