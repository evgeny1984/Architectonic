using Ar.Generator.Data.Models.SolutionAppConfig;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ar.Generator.Data.Models.Deployments
{
    [Table(nameof(Deployment))]
    public class Deployment : BaseEntity
    {
        #region FKs

        public int ApplicationId { get; set; }

        #endregion

        #region Columns

        public string DockerRegistry { get; set; }

        public DeploymentType DeploymentType { get; set; }

        #endregion

        #region Relationships

        public Application Application { get; set; }

        #endregion

    }
}
