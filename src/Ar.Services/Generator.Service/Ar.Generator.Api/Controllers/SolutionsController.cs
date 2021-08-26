using Ar.Generator.Service.Services;
using Architect.Dto.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ar.Generator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolutionsController : ControllerBase
    {
        private readonly ILogger _logger;
        private ISolutionService _solutionService;

        public SolutionsController(ISolutionService solutionService, ILogger<SolutionsController> logger)
        {
            _solutionService = solutionService;
            _logger = logger;
        }

        // GET: api/solution
        [HttpGet]
        public async Task<IEnumerable<SolutionDto>> GetMappingTables()
        {
            return await _solutionService.GetAll();
        }

        // GET: api/solution/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SolutionDto>> GetSolution(int id)
        {
            var solution = await _solutionService.GetWithDetails(id);

            if (solution == null)
            {
                return NotFound();
            }

            return solution;
        }

        // PUT: api/solution/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSolution(int id, SolutionDto solution)
        {
            if (id != solution.Id)
            {
                return BadRequest();
            }

            await _solutionService.Update(solution);

            return CreatedAtAction(nameof(PutSolution), solution.Id);
        }

        // POST: api/solution
        [HttpPost]
        public async Task<ActionResult<int>> PostSolution(SolutionDto solution)
        {
            int pk = await _solutionService.Create(solution);

            return CreatedAtAction(nameof(PostSolution), new { id = pk }, pk);
        }

        // DELETE: api/solution/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSolution(int id)
        {
            await _solutionService.Delete(id);
            return NoContent();
        }
    }
}
