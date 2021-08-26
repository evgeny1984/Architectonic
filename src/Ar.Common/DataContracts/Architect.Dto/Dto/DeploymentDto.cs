using System.Collections.Generic;

namespace Architect.Dto.Dto
{
    public class DeploymentDto : BaseEntityDto
    {
        #region FKs

        public int ApplicationId { get; set; }

        #endregion

        #region Columns

        public string DockerRegistry { get; set; }

        public DeploymentType DeploymentType { get; set; }

        #endregion

    }
}
