using Architect.Dto.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ar.Generator.Service.Services
{
    public interface ISolutionService : IEntityService<SolutionDto>
    {
        Task<IEnumerable<SolutionDto>> GetAll();
        Task<int> Update(SolutionDto solution);
        Task<int> Create(SolutionDto solution);
        Task Delete(int id);
        Task<IEnumerable<SolutionDto>> GetAllWithChildren();
    }
}
