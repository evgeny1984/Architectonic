using Architect.Dto.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ar.Generator.Service.Services
{
    public interface IGeneratorService 
    {  
        Task GenerateSolution(SolutionDto solution);      
    }
}
