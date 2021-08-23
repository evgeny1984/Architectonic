using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Architect.Dto.Dto;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Ar.Web.Helpers
{
    public class BaseHttpClient : IHttpClientService
    {
        private readonly ILogger logger;
        private static readonly JsonSerializerSettings _JsonSettings = new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore, DateFormatHandling = DateFormatHandling.MicrosoftDateFormat, NullValueHandling = NullValueHandling.Ignore, ReferenceLoopHandling = ReferenceLoopHandling.Serialize };
        private readonly HttpClient httpClient;

        public HttpRequestHeaders DefaultRequestHeaders => httpClient.DefaultRequestHeaders;


        public BaseHttpClient(HttpClient httpClient, ILogger<BaseHttpClient> logger)
        {
            this.logger = logger;
            this.httpClient = httpClient;
        }

        /// <summary>
        /// Load the file from the microservice based on the querystring
        /// </summary>
        /// <param name="queryString">The endpoint of the microservice</param>
        /// <returns>The file in base64 format</returns>
        public async Task<FileContentResult> GetFile(string queryString)
        {
            // Build request
            try
            {
                using (var response = await httpClient.GetAsync(queryString))
                {
                    // Ensure that the response was successful
                    if (response.IsSuccessStatusCode == false)
                    {
                        ThrowWebException(response, $"Error by calling the function {nameof(GetFile)}");
                    }

                    logger.LogInformation($"Got the response from Gateway, ensure the response was successful.");
                    var stream = await response.Content.ReadAsByteArrayAsync();

                    // Get file name from query string
                    var splittedParts = queryString.Split('/');
                    string fileName = string.Empty;
                    string fileExtension = string.Empty;

                    // Check the length of the splitted array
                    if (splittedParts.Length > 0)
                    {
                        fileName = splittedParts[splittedParts.Length - 1];
                        fileExtension = Path.GetExtension(fileName).Replace(".", "");
                    }

                    return new FileContentResult(stream, $"application/{fileExtension}")
                    {
                        FileDownloadName = fileName
                    };
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Call is not successful {ex.Message}");
                throw;
            }
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
                logger.LogError($"Call is not successful {ex.Message}");
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
                logger.LogError($"Call is not successful {ex.Message}");
                throw;
            }

            return result;
        }

        public async Task<T> Post<T>(string queryString, object content) where T : new()
        {
            using (var httpContent = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json"))
            {
                return await Post<T>(queryString, httpContent);
            }
        }

        public async Task<T> Post<T>(string queryString, HttpContent httpContent) where T : new()
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
                logger.LogError($"Call is not successful {ex.Message}");
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
                logger.LogError($"Call is not successful {ex.Message}");
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
                logger.LogError($"Call is not successful {ex.Message}");
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
                logger.LogError($"Call is not successful {ex.Message}");
                throw;
            }
        }

        #region Helper functions

        /// <summary>
        /// Track WebException and get error message from Response.
        /// </summary>    
        private void ThrowWebException(HttpResponseMessage response, string content)
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

        #endregion



    }
}
