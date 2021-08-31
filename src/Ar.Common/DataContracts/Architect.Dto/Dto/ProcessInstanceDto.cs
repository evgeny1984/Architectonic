using System.Collections.Generic;

namespace Architect.Dto.Dto
{
    public class ProcessInstanceDto : BaseEntityDto
    {
        public ProcessInstanceDto()
        {
            BpmnActivities = new List<BpmnActivityDto>();
        }


        #region FKs

        public int WorkflowEngineId { get; set; }

        #endregion

        #region Columns

        public string Name { get; set; }

        public string BpmnXml { get; set; }

        #endregion

        #region Relationships

        public ICollection<BpmnActivityDto> BpmnActivities { get; set; }

        #endregion

    }
}
