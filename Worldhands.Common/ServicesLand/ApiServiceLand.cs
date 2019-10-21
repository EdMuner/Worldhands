using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Worldhands.Common.ModelsLand;

namespace Worldhands.Common.ServicesLand
{
    public class ApiServiceLand
    {

        public async Task<LandResponse> GetList<T>(
          string urlBase,
          string servicePrefix,
          string controller)
        {

            {
                try
                {
                    var client = new HttpClient();
                    client.BaseAddress = new Uri(urlBase);
                    var url = string.Format("{0}{1}", servicePrefix, controller);
                    var response = await client.GetAsync(url);
                    var result = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        return new LandResponse
                        {
                            IsSuccess = false,
                            Message = result,
                        };
                    }

                    var list = JsonConvert.DeserializeObject<List<T>>(result);
                    return new LandResponse
                    {
                        IsSuccess = true,
                        Message = "Ok",
                        Result = list
                    };
                }
                catch (Exception ex)
                {
                    return new LandResponse
                    {
                        IsSuccess = false,
                        Message = ex.Message,
                    };
                }
            }
        }
    }
}
