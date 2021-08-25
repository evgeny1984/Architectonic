using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ar.Generator.Data.Models.ArchitecturalPatterns
{
    [Table(nameof(ProcessInstance))]
    public class ProcessInstance : BaseEntity
    {
        public ProcessInstance()
        {
            BpmnActivities = new List<BpmnActivity>();
        }


        #region FKs

        public int WorkflowEngineId { get; set; }

        #endregion

        #region Columns

        public string Name { get; set; }

        public string BpmnXml{ get; set; }

        #endregion

        #region Relationships

        public ICollection<BpmnActivity> BpmnActivities { get; set; }

        public WorkflowEngine WorkflowEngine { get; set; }

        #endregion
    }
}
