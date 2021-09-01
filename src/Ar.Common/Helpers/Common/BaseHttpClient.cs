using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Architect.Dto.Dto;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Ar.Common.Helpers
{
    public class BaseHttpClient : IHttpClientService
    {
        private readonly ILogger logger;
        private static JsonSerializerSettings _JsonSettings = new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore, DateFormatHandling = DateFormatHandling.MicrosoftDateFormat, NullValueHandling = NullValueHandling.Ignore, ReferenceLoopHandling = ReferenceLoopHandling.Serialize };
        private readonly HttpClient httpClient;

        public HttpRequestHeaders DefaultRequestHeaders => httpClient.DefaultRequestHeaders;


        public BaseHttpClient(HttpClient httpClient, ILogger<BaseHttpClient> logger)
        {
            this.logger = logger;
            this.httpClient = httpClient;
        }

        public async Task<string> Get(string queryString)
        {
            // Build request
            try
            {
                using (var response = await httpClient.GetAsync(queryString))
                {
                    logger.LogInformation($"Got the response from Gateway, ensure the response was successful.");
                    string content = await response.Content.ReadAsStringAsync();
                    // Ensure that the response was successful
                    if (response.IsSuccessStatusCode == false)
                    {
                        ThrowWebException(response, content);
                    }
                    return content;
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Call is Cct successful {ex.Message}");
                throw;
            }
        }

        public async Task<T> Get<T>(string queryString) where T : new()
        {
            // Build request
            T result = default;
            try
            {
                using (var response = await httpClient.GetAsync(queryString))
                {
                    logger.LogInformation($"Got the response from Gateway, ensure the response was successful.");
                    string json = await response.Content.ReadAsStringAsync();
                    // Ensure that the response was successful
                    if (response.IsSuccessStatusCode == false)
                    {
                        ThrowWebException(response, json);
                    }
                    result = JsonConvert.DeserializeObject<T>(json, _JsonSettings);
                    logger.LogInformation($"The serialization was successful, return the result...");
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Call is Cct successful {ex.Message}");
                throw;
            }

            return result;
        }

        public async Task<T> Post<T>(string queryString, object content)
        {
            using (var httpContent = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json"))
            {
                return await Post<T>(queryString, httpContent);
            }
        }

        public async Task<T> Post<T>(string queryString, HttpContent httpContent)
        {
            T result = default;
            try
            {
                using (var response = await httpClient.PostAsync(queryString, httpContent))
                {
                    logger.LogInformation($"Got the response from Gateway, ensure the response was successful.");
                    var json = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode == false)
                    {
                        ThrowWebException(response, json);
                    }
                    result = JsonConvert.DeserializeObject<T>(json, _JsonSettings);
                    logger.LogInformation($"The serialization was successful, return the result...");
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Call is Cct successful {ex.Message}");
                throw;
            }

            return result;
        }

        public async Task Put(string queryString, object content)
        {
            try
            {
                using (var httpContent = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json"))
                using (var response = await httpClient.PutAsync(queryString, httpContent))
                {
                    logger.LogInformation($"Got the response from Gateway, ensure the response was successful.");
                    string json = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode == false)
                    {
                        ThrowWebException(response, json);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Call is Cct successful {ex.Message}");
                throw;
            }
        }


        public async Task<T> Put<T>(string queryString, object content) where T : new()
        {
            T result = default;
            try
            {
                using (var httpContent = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json"))
                using (var response = await httpClient.PutAsync(queryString, httpContent))
                {
                    logger.LogInformation($"Got the response from Gateway, ensure the response was successful.");
                    string json = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode == false)
                    {
                        ThrowWebException(response, json);
                    }
                    result = JsonConvert.DeserializeObject<T>(json, _JsonSettings);
                    logger.LogInformation($"The serialization was successful, return the result...");
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Call is Cct successful {ex.Message}");
                throw;
            }

            return result;
        }


        public async Task Delete(string queryString)
        {
            try
            {
                using (var response = await httpClient.DeleteAsync(queryString))
                {
                    logger.LogInformation($"Got the response from Gateway, ensure the response was successful.");
                    string json = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode == false)
                    {
                        ThrowWebException(response, json);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Call is Cct successful {ex.Message}");
                throw;
            }
        }


        /// <summary>
        /// Track WebException and get error message from Response.
        /// </summary>    
        internal void ThrowWebException(HttpResponseMessage response, string content)
        {
            ApiError error;
            try
            {
                error = JsonConvert.DeserializeObject<ApiError>(content);
            }
            catch
            {
                error = null;
            }
            if (!string.IsNullOrWhiteSpace(error?.Message))
            {
                throw new HttpRequestException(error.Message);
            }

            throw new HttpRequestException(
                $"{response.ReasonPhrase ?? "Internal Server Error"}\n\n{content}");
        }

    }
}
