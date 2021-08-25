using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ar.Generator.Data.Models.ArchitecturalPatterns
{
    [Table(nameof(WorkflowEngine))]
    public class WorkflowEngine : BaseEntity
    {
        public WorkflowEngine()
        {
            ProcessInstances = new List<ProcessInstance>();
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

        public ICollection<ProcessInstance> ProcessInstances { get; set; }

        public SagaPattern SagaPattern { get; set; }

        #endregion
    }
}
