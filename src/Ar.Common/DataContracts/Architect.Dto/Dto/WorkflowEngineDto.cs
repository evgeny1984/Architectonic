using System.Collections.Generic;

namespace Architect.Dto.Dto
{
    public class WorkflowEngineDto : BaseEntityDto
    {
        public WorkflowEngineDto()
        {
            ProcessInstances = new List<ProcessInstanceDto>();
        }

        #region FKs

        public int SagaPatternId { get; set; }

        #endregion

        #region Columns

        public string RestApi { get; set; }

        public bool IsAuthorizationRequired { get; set; }

        public bool IsWebModelerIncluded { get; set; }

        #endregion

        #region Relationships

        public ICollection<ProcessInstanceDto> ProcessInstances { get; set; }

        #endregion

    }
}
