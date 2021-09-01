using Ar.Compiler.Service.Services;
using Architect.Dto.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;

namespace Ar.Compiler.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecognitionController : ControllerBase
    {
        private readonly ILogger<RecognitionController> _logger;
        private IRecognitionService _recognitionService;

        public RecognitionController(IRecognitionService recognitionService, ILogger<RecognitionController> logger)
        {
            _logger = logger;
            _recognitionService = recognitionService;
        }

        [Route("recognize")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> RecognizeAsync([FromBody] FileDto adlFile)
        {
            // TODO Call the recognition service to interpret the ADL
            await _recognitionService.RecognizeProvidedAdl(adlFile);

            return Accepted();
        }

    }
}
