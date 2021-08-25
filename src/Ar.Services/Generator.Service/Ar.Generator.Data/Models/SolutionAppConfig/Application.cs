using Ar.Generator.Data.Models.ArchitecturalPatterns;
using Ar.Generator.Data.Models.Deployments;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ar.Generator.Data.Models.SolutionAppConfig
{
    [Table(nameof(Application))]
    public class Application : BaseEntity
    {
        public Application()
        {
            Deployments = new List<Deployment>();
            BpmnActivityHandlers = new List<BpmnActivityHandler>();
        }

        #region FKs

        public int ConfigurationId { get; set; }

        public int SolutionId { get; set; }

        #endregion

        #region Columns

        public string Name { get; set; }

        public bool IncludeDockerFile{ get; set; }

        #endregion

        #region Relationships

        public ICollection<Deployment> Deployments { get; set; }

        public ICollection<BpmnActivityHandler> BpmnActivityHandlers { get; set; }

        public AppConfig Configuration { get; set; }

        public Solution Solution { get; set; }

        #endregion
    }
}
