using Ar.Generator.Data.Models.SolutionAppConfig;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ar.Generator.Data.Models.ArchitecturalPatterns
{
    [Table(nameof(BpmnActivityHandler))]
    public class BpmnActivityHandler : BaseEntity
    {
        #region FKs

        public int ResponsibleApplicationId { get; set; }

        #endregion

        #region Columns

        public string Name { get; set; }

        public string TransactionEndpoint { get; set; }

        public string CompensatingTransactionEndpoint { get; set; }

        public bool NotifyOnFailure { get; set; }

        #endregion

        #region Relationships

        public Application ResponsibleApplication { get; set; }

        public BpmnActivity BpmnActivity { get; set; }

        #endregion
    }
}
