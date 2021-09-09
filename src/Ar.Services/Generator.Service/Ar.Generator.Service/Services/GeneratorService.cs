using Architect.Dto.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ar.Generator.Service.Services
{
    public class GeneratorService : IGeneratorService
    {
        private INodeJsService _nodeJsService;

        public GeneratorService(INodeJsService nodeJsService)
        {
            _nodeJsService = nodeJsService;
        }

        public async Task GenerateSolution(SolutionDto solution)
        {
            var result = await _nodeJsService.AddNumbers(3, 5);
        }
    }
}
