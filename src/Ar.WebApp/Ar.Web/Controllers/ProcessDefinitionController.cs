using Camunda.Api.Client;
using Camunda.Api.Client.Deployment;
using Camunda.Api.Client.ProcessDefinition;
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
    public class ProcessDefinitionController : Controller
    {
        private readonly ILogger _logger;
        private readonly string _StandardURLParameters = "";
        private IHttpClientService _baseHttpClient;
        private readonly CamundaClient _CamundaClient;

        public ProcessDefinitionController(IHttpClientService baseHttpClient, IOptionsSnapshot<AppSettings> appSettings, ILogger<ProcessDefinitionController> logger)
        {
            _baseHttpClient = baseHttpClient;
            _logger = logger;
            _StandardURLParameters = appSettings.Value.CamundaEngineUrl;
            _logger.LogInformation(_StandardURLParameters);
            _CamundaClient = CamundaClient.Create(_StandardURLParameters);
        }

        [HttpGet]
        public async Task<IEnumerable<ProcessDefinitionInfo>> GetProcessDefinitions()
        {
            var result = await _CamundaClient.ProcessDefinitions.Query().List();

            return result;
        }

        // GET api/CamundaEngine/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProcessDefinition([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _CamundaClient.ProcessDefinitions[id].Get();

            return Ok(result);
        }

        [HttpGet("{id}/xml")]
        public async Task<IActionResult> GetProcessDiagram([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var diagram = await _CamundaClient.ProcessDefinitions[id].GetXml();

            return Ok(diagram);
        }

        // TODO POST api/<CamundaEngineController>
        [HttpPost]
        public async Task<IActionResult> PostProcessDefinition([FromBody] ProcessDeployment deployment)
        {
            if (string.IsNullOrEmpty(deployment.Bpmn20Xml))
                return BadRequest(ModelState);

            // Get steam from string for the request
            var stream = UtilFunctions.GetStreamFromText(deployment.Bpmn20Xml);
            DeploymentInfo deploymentInfo;
            try
            {
                deploymentInfo = await _CamundaClient.Deployments.Create(
                     deployment.Name,
                     true,
                     true,
                     null,
                     null,
                     new ResourceDataContent(stream, $"{deployment.Name}.bpmn"));
            }
            catch (Exception e)
            {
                throw new ApplicationException("Failed to deploy process definition", e);
            }

            return Ok(deploymentInfo);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> StartProcessDefinition(string processDefinitionId)
        {
            await _CamundaClient.ProcessDefinitions[processDefinitionId].StartProcessInstance(null);

            return Ok();
        }

        // PUT api/<CamundaEngineController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] string id, [FromBody] ProcessDefinition processDefinition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != processDefinition.Id)
            {
                return BadRequest();
            }

            string queryString = $"{_StandardURLParameters}/{id}";
            await _baseHttpClient.Put<ProcessDefinition>(queryString, processDefinition);

            return NoContent();
        }

        // DELETE api/<CamundaEngineController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _CamundaClient.ProcessDefinitions[id].Delete(false, true, true);

            return Ok($"Process definition with ID: {id} was deleted successfuly.");
        }
    }
}
