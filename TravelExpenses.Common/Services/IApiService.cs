﻿using System.Threading.Tasks;
using TravelExpenses.Common.Models;

namespace TravelExpenses.Common.Services
{
    public interface IApiService
    {
        Task<Response> GetTravelAsync(int id, string urlBase, string servicePrefix, string controller); 

        Task<Response> GetTokenAsync(string urlBase, string servicePrefix, string controller, TokenRequest request);

        Task<Response> GetUserByEmail(string urlBase, string servicePrefix, string controller, string tokenType, string accessToken, EmailRequest request);

    }

}