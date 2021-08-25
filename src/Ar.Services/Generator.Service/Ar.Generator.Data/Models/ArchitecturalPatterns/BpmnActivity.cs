using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ar.Generator.Data.Models.ArchitecturalPatterns
{
    [Table(nameof(BpmnActivity))]
    public class BpmnActivity : BaseEntity
    {
        public BpmnActivity()
        {
            BpmnActivityVars = new List<BpmnActivityVar>();
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

        public ICollection<BpmnActivityVar> BpmnActivityVars { get; set; }

        public BpmnActivityHandler ActivityHandler { get; set; }

        public ProcessInstance ProcessInstance { get; set; }

        #endregion
    }
}
