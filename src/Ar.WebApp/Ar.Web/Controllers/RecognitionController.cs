using Ar.Common.Helpers;
using Ar.Web.Helpers;
using Architect.Dto.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace Ar.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecognitionController : Controller
    {
        private readonly ILogger _logger;
        private readonly string _StandardURLParameters = "";
        private IHttpClientService _baseHttpClient;

        public RecognitionController(IHttpClientService baseHttpClient, IOptionsSnapshot<AppSettings> appSettings, ILogger<RecognitionController> logger)
        {
            _baseHttpClient = baseHttpClient;
            _logger = logger;
            _StandardURLParameters = appSettings.Value.ServiceGatewayUrl;
        }

        [HttpPost]
        public async Task RecognizeAsync([FromBody] FileDto adlFile)
        {
            string queryString = $"{_StandardURLParameters}/compiler/recognition/recognize";
            await _baseHttpClient.Post<IActionResult>(queryString, adlFile);
        }

    }
}
