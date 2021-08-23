using Camunda.Api.Client;
using Camunda.Api.Client.Message;
using Camunda.Api.Client.Signal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Ar.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Architect.Dto.Dto.Camunda;

namespace Ar.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : Controller
    {
        private readonly ILogger _logger;
        private readonly string _StandardURLParameters = "";
        private IHttpClientService _baseHttpClient;
        private readonly CamundaClient _CamundaClient;

        public MessageController(IHttpClientService baseHttpClient, IOptionsSnapshot<AppSettings> appSettings, ILogger<ProcessDefinitionController> logger)
        {
            _baseHttpClient = baseHttpClient;
            _logger = logger;
            _StandardURLParameters = appSettings.Value.CamundaEngineUrl;
            _CamundaClient = CamundaClient.Create(_StandardURLParameters);
        }

        // TODO POST api/<CamundaEngineController>
        [HttpPost]
        public async Task<IActionResult> CorrelateMessage([FromBody] CamundaMessage message)
        {
            if (message == null)
                return BadRequest(ModelState);

            Dictionary<string, VariableValue> variables = null;
            if (message.Data != null)
            {
                variables = new Dictionary<string, VariableValue>();
                variables.Add(message.Data.Name, VariableValue.FromObject(message.Data.Value));
            }

            CorrelationMessage msg = new CorrelationMessage()
            {
                ResultEnabled = true,
                MessageName = message.MessageName,
                BusinessKey = message.BusinessKey,
                ProcessVariables = variables
            };

            try
            {
                var correlationResult = await _CamundaClient.Messages.DeliverMessage(msg);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to send a message", ex);
            }

            return NoContent();
        }

        [HttpPost("signalName")]
        public async Task<IActionResult> ThrowSignal([FromRoute] string signalName)
        {
            if (string.IsNullOrEmpty(signalName))
                return BadRequest(ModelState);

            Signal signal = new Signal()
            {
                Name = signalName
            };

            try
            {
                await _CamundaClient.Signals.ThrowSignal(signal);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to throw a signal", ex);
            }

            return NoContent();
        }

    }
}
