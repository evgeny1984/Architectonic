using Ar.Generator.Data.Models.Deployments;
using Ar.Generator.Data.Models.SolutionAppConfig;
using System;
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
        }

        #region Columns

        public string Name { get; set; }

        public bool IncludeDockerFile{ get; set; }

        #endregion

        #region Relationships
        public ICollection<Deployment> Deployments { get; set; }

        public AppConfig Configuration { get; set; }

        #endregion
    }
}
