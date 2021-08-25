using Ar.Generator.Data.Models.ArchitecturalPatterns;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ar.Generator.Data.Models.SolutionAppConfig
{
    [Table(nameof(Solution))]
    public class Solution : BaseEntity
    {
        public Solution()
        {
            Applications = new List<Application>();
            Patterns = new List<DesignPattern>();
            SolutionStructure = new List<Folder>();
        }

        #region Columns

        public string Name { get; set; }

        public string RepositoryName { get; set; }

        #endregion

        #region Relationships

        public ICollection<Application> Applications { get; set; }

        public ICollection<DesignPattern> Patterns { get; set; }

        public ICollection<Folder> SolutionStructure { get; set; }

        #endregion
    }
}
