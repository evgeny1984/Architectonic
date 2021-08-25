using Ar.Generator.Data.Models.SolutionAppConfig;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ar.Generator.Data.Models.ArchitecturalPatterns
{
    [Table(nameof(DesignPattern))]
    public class DesignPattern : BaseEntity
    {

        #region FKs

        public int SolutionId { get; set; }

        #endregion

        #region Columns

        public string Name { get; set; }

        public string Problem { get; set; }

        #endregion

        #region Relationships

        public Solution Solution { get; set; }

        #endregion
    }
}
