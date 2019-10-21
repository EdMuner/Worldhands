using System.Threading.Tasks;
using Worldhands.Common.Models;

namespace Worldhands.Common.Services
{
    public interface IApiService
    {
        Task<LandResponse<VisitorResponse>> GetVisitorByEmailAsync(
            string urlBase,
            string servicePrefix,
            string controller,
            string tokenType,
            string accessToken,
            string email);

        Task<LandResponse<TokenResponse>> GetTokenAsync(
            string urlBase,
            string servicePrefix,
            string controller,
            TokenRequest request);

      
        Task<bool> CheckConnectionAsync(string url);

       
    }
}