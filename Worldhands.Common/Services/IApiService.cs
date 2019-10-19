using System.Threading.Tasks;
using Worldhands.Common.Models;

namespace Worldhands.Common.Services
{
    public interface IApiService
    {
        Task<Response<VisitorResponse>> GetVisitorByEmailAsync(
            string urlBase,
            string servicePrefix,
            string controller,
            string tokenType,
            string accessToken,
            string email);

        Task<Response<TokenResponse>> GetTokenAsync(
            string urlBase,
            string servicePrefix,
            string controller,
            TokenRequest request);
    }
}