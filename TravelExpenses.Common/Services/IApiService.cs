using System.Threading.Tasks;
using TravelExpenses.Common.Models;

namespace TravelExpenses.Common.Services
{
    public interface IApiService
    {
        Task<Response> GetTravelAsync(int id, string urlBase, string servicePrefix, string controller);
    }
}
