using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Ar.Common.Helpers
{
    public interface IHttpClientService
    {
        HttpRequestHeaders DefaultRequestHeaders { get; }
        Task<string> Get(string queryString);
        Task<T> Get<T>(string queryString) where T : new();
        Task<T> Post<T>(string queryString, object content);
        Task<T> Post<T>(string queryString, HttpContent httpContent);
        Task Put(string queryString, object content);
        Task<T> Put<T>(string queryString, object content) where T : new();
        Task Delete(string queryString);
    }
}
