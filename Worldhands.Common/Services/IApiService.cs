using System.Threading.Tasks;
using Worldhands.Common.Models;

namespace Worldhands.Common.Services
{
    public interface IApiService
    {
        Task<Response> GetVisitorByEmailAsync(
            string urlBase,
            string servicePrefix,
            string controller,
            string tokenType,
            string accessToken,
            string email);

        Task<Response> GetTokenAsync(
            string urlBase,
            string servicePrefix,
            string controller,
            TokenRequest request);

        Task<Response> GetListLandsAsync<T>(
           string urlBase,
           string servicePrefix,
           string controller);




        Task<bool> CheckConnectionAsync(string url);


    }
}