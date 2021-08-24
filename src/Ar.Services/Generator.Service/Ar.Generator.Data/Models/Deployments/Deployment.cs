using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ar.Generator.Data.Models.Deployments
{
    [Table(nameof(Deployment))]
    public class Deployment : BaseEntity
    {
        #region Columns

        public string DockerRegistry { get; set; }

        public DeploymentType DeploymentType { get; set; }

        #endregion

    }
}
