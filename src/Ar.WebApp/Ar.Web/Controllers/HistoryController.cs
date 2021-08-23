using Camunda.Api.Client;
using Camunda.Api.Client.History;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Ar.Web.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ar.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : Controller
    {
        private readonly ILogger _logger;
        private readonly string _StandardURLParameters = "";
        private IHttpClientService _baseHttpClient;
        private readonly CamundaClient _CamundaClient;

        public HistoryController(IHttpClientService baseHttpClient, IOptionsSnapshot<AppSettings> appSettings, ILogger<ProcessDefinitionController> logger)
        {
            _baseHttpClient = baseHttpClient;
            _logger = logger;
            _StandardURLParameters = appSettings.Value.CamundaEngineUrl;
            _CamundaClient = CamundaClient.Create(_StandardURLParameters);
        }

        [HttpGet]
        public async Task<IEnumerable<HistoricProcessInstance>> GetProcessDefinitions()
        {
            var result = await _CamundaClient.History.ProcessInstances.Query().List();

            return result;
        }

    }
}
