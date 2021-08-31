using System.Collections.Generic;

namespace Architect.Dto.Dto
{
    public class BpmnActivityDto : BaseEntityDto
    {
        public BpmnActivityDto()
        {
            BpmnActivityVars = new List<BpmnActivityVarDto>();
        }

        #region FKs

        public int ActivityHandlerId { get; set; }

        public int ProcessInstanceId { get; set; }

        #endregion

        #region Columns

        public string SubscriptionTopic { get; set; }

        public string TimeoutPattern { get; set; }

        public ActivityTaskType TaskType { get; set; }

        #endregion

        #region Relationships

        public ICollection<BpmnActivityVarDto> BpmnActivityVars { get; set; }

        public BpmnActivityHandlerDto ActivityHandler { get; set; }

        #endregion

    }
}
