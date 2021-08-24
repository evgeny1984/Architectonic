using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ar.Generator.Data.Models.Deployments
{
    [Table(nameof(Kubernetes))]
    public class Kubernetes : Deployment
    {

        public Kubernetes()
        {
            EnvVars = new List<EnvironmentVar>();
        }

        #region Columns

        public string YamlConfig { get; set; }
        public string Namespace { get; set; }
        public string IngressDomain { get; set; }
        public int ReplicasAmount{ get; set; }
        public WorkloadType WorkloadType { get; set; }

        #endregion

        #region Relationships

        public PersistenVolumeClaim PVC { get; set; }
        public ICollection<EnvironmentVar> EnvVars { get; set; }

        #endregion

    }
}
