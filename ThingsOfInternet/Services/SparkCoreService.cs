using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ThingsOfInternet.Dtos;
using ThingsOfInternet.Models;

namespace ThingsOfInternet.Services
{
    public class SparkCoreService : ServiceBase
    {
        public async Task<SparkFunctionResponse> InvokeAsync(string requestUrl, IDictionary<string, string> content)
        {
            return await CallFunctionAsync(requestUrl, content);
        }

        public async Task<T> QueryAsync<T>(string requestUrl)
        {
            var query = default(T);
            var response = await GetVariableAsync(requestUrl);

            if (response != null)
            {
                query = JsonConvert.DeserializeObject<T>(response.Result);
            }

            return query;
        }

        protected async Task<SparkFunctionResponse> CallFunctionAsync(string requestUrl, IDictionary<string, string> content)
        {
            return await MakeRequestAsync<SparkFunctionResponse>(async (client) =>
                {
                    var result = await client.PostAsync(requestUrl, new FormUrlEncodedContent(content));
                    return await result.Content.ReadAsStringAsync();
                });
        }

        protected async Task<SparkVariableResponse> GetVariableAsync(string requestUrl)
        {
            return await MakeRequestAsync<SparkVariableResponse>(async (client) => await client.GetStringAsync(requestUrl));
        }

        protected async Task<TResponse> MakeRequestAsync<TResponse>(Func<HttpClient, Task<string>> responseAction)
        {
            TResponse response = default(TResponse);
            string responseString = null;
            try
            {
                using (var client = new HttpClient())
                {
                    responseString = await responseAction(client);
                }
            }
            catch (Exception e)
            {
                // TODO: logging
                Logger.Error("Spark Core request failed.", e);

                throw e;
            }

            if (!string.IsNullOrWhiteSpace(responseString) && responseString.Contains("error"))
            {
                var error = JsonConvert.DeserializeObject<SparkError>(responseString);
                throw new WebServiceException(error.ErrorMessage);
            }

            if (!string.IsNullOrWhiteSpace(responseString))
            {
                response = JsonConvert.DeserializeObject<TResponse>(responseString);
            }

            return response;
        }
    }
}

