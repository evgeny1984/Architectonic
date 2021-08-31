using System.Collections.Generic;

namespace Architect.Dto.Dto
{
    public class DockerComposeServiceDto : BaseEntityDto
    {
        public DockerComposeServiceDto()
        {
            EnvVars = new List<EnvironmentVarDto>();
        }

        #region FKs

        public int DockerComposeId { get; set; }

        #endregion

        #region Columns

        public string Name { get; set; }

        public string Ports { get; set; }

        #endregion

        #region Relationships

        public ICollection<EnvironmentVarDto> EnvVars { get; set; }

        #endregion

    }
}
