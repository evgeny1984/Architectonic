using Architect.Dto.Dto;
using System.Threading.Tasks;

namespace Ar.Compiler.Service.Services
{
    public interface ITransformationService
    {
        Task<SolutionDto> TransformToSemanticModel(FileDto adlFile);
    }
}
