using System.Collections.Generic;

namespace Architect.Dto.Dto
{
    public class ApplicationDto : BaseEntityDto
    {
        public ApplicationDto()
        {
            Deployments = new List<DeploymentDto>();
            BpmnActivityHandlers = new List<BpmnActivityHandlerDto>();
        }

        #region FKs

        public int ConfigurationId { get; set; }

        public int SolutionId { get; set; }

        #endregion

        #region Columns

        public string Name { get; set; }

        public bool IncludeDockerFile { get; set; }

        #endregion

        #region Relationships

        public ICollection<DeploymentDto> Deployments { get; set; }

        public ICollection<BpmnActivityHandlerDto> BpmnActivityHandlers { get; set; }

        #endregion

    }
}
