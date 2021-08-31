using Ar.Web.Helpers;
using Architect.Dto.Dto;
using Camunda.Api.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ar.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolutionsController : Controller
    {
        private readonly ILogger _logger;
        private readonly string _StandardURLParameters = "";
        private IHttpClientService _baseHttpClient;

        public SolutionsController(IHttpClientService baseHttpClient, IOptionsSnapshot<AppSettings> appSettings, ILogger<ProcessDefinitionController> logger)
        {
            _baseHttpClient = baseHttpClient;
            _logger = logger;
            _StandardURLParameters = appSettings.Value.ServiceGatewayUrl;
        }

        // GET: api/solutions
        [HttpGet]
        public async Task<IEnumerable<SolutionDto>> GetSolutions()
        {
            // Build url
            string queryString = $"{_StandardURLParameters}/generator/solutions";
            var result = await _baseHttpClient.Get<List<SolutionDto>>(queryString);

            return result;
        }

        // GET: api/solution/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SolutionDto>> GetSolution(int id)
        {
            // Build url
            string queryString = $"{_StandardURLParameters}/generator/solutions/{id}";
            var result = await _baseHttpClient.Get<SolutionDto>(queryString);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        // PUT: api/solution/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSolution(int id, SolutionDto solution)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != solution.Id)
            {
                return BadRequest();
            }

            string queryString = $"{_StandardURLParameters}/generator/solutions/{solution.Id}";
            await _baseHttpClient.Put(queryString, solution);

            return Accepted();
        }

        // POST: api/solution
        [HttpPost]
        public async Task<ActionResult<int>> PostSolution(SolutionDto solution)
        {
            string queryString = $"{_StandardURLParameters}/generator/solutions";
            return await _baseHttpClient.Post<int>(queryString, solution);
        }

        // DELETE: api/solution/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSolution(int id)
        {
            string queryString = $"{_StandardURLParameters}/generator/solutions/{id}";
            await _baseHttpClient.Delete(queryString);
            return NoContent();
        }
    }
}
