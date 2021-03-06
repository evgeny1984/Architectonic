using Architect.Dto.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ar.Compiler.Service.Services
{
    public class TransformationService : ITransformationService
    {
        public async Task<SolutionDto> TransformToSemanticModel(FileDto adlFile)
        {
            SolutionDto semanticModel = new SolutionDto()
            {
                Name = adlFile.Name,
                RepositoryName = "https://github.com/username/userepository.git",
                Description = adlFile.Description,
                AdlContent = adlFile.Body,
                Applications = new List<ApplicationDto>(),
                Patterns = new List<DesignPatternDto>(),
                SolutionStructure = new List<FolderDto>(),
                AddedAt = adlFile.CreatedAt,
                ModifiedAt = adlFile.CreatedAt
            };
            return semanticModel;
        }
    }
}
