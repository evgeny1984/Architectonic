using Ar.Generator.Data.Models.EntityModel;
using Architect.Dto.Dto;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ar.Generator.Data.Models.Deployments
{
    [Table(nameof(EnvironmentVar))]
    public class EnvironmentVar : BaseEntity
    {
        public EnvironmentVar()
        {
            DockerComposeServices = new List<DockerComposeService>();
        }

        #region FKs

        public int KubernetesId { get; set; }

        #endregion

        #region Columns

        public string Name { get; set; }
        public string Value { get; set; }
        public EnvType Type { get; set; }

        #endregion

        #region Relationships

        public Kubernetes Kubernetes { get; set; }

        public ICollection<DockerComposeService> DockerComposeServices { get; set; }

        #endregion

    }
}
