using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TravelExpenses.Common.Models;


namespace TravelExpenses.Common.Services
{
    public class ApiService : IApiService
    {
        public async Task<Response> GetTravelAsync(int id, string urlBase, string servicePrefix, string controller)
        {
            try
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase),
                };

                string url = $"{servicePrefix}{controller}/{id}";
                HttpResponseMessage response = await client.GetAsync(url);
                string result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                TravelResponse model = JsonConvert.DeserializeObject<TravelResponse>(result);
                return new Response
                {
                    IsSuccess = true,
                    Result = model
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

    }
}
