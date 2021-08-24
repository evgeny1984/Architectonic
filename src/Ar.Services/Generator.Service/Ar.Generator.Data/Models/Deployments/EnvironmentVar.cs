using Ar.Generator.Data.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ar.Generator.Data.Models.Deployments
{
    [Table(nameof(EnvironmentVar))]
    public class EnvironmentVar : BaseEntity
    {

        #region Columns

        public string Name { get; set; }
        public string Value { get; set; }
        public EnvType Type { get; set; }

        #endregion

        #region Relationships

        public DbEngine Kubernetes { get; set; }
        public DockerComposeService DockerComposeService { get; set; }

        #endregion

    }
}
