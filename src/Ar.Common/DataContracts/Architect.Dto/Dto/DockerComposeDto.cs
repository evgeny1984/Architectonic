using System.Collections.Generic;

namespace Architect.Dto.Dto
{
    public class DockerComposeDto : BaseEntityDto
    {
        public DockerComposeDto()
        {
            DockerComposeServices = new List<DockerComposeServiceDto>();
        }

        #region Columns

        public bool IncludeDockerFile { get; set; }

        #endregion

        #region Relationships

        public ICollection<DockerComposeServiceDto> DockerComposeServices { get; set; }

        #endregion

    }
}
